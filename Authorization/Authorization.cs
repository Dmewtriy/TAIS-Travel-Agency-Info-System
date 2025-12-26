using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AuthorizationLibrary
{
    public struct MenuState
    {
        public int R; // Чтение
        public int W; // Запись
        public int E; // Изменение
        public int D; // Удаление 

    }
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public Dictionary<int, MenuState> MenuStatus { get; set; } = new Dictionary<int, MenuState>();
    }
    public class Authorization
    {
        // Имя файла БД
        private readonly string DatabaseFileName = "Login.db";
        // Относительный путь от корневой папки проекта до Data/DataFiles
        private readonly string RelativeDbPath = Path.Combine("Data", "DataFiles");

        private string ConnectionString;
        public Dictionary<string, User> users { get; private set; } = new Dictionary<string, User>();
        public SettingsRepository _settingsRepository;

        public Authorization()
        {
            SQLitePCL.Batteries.Init();
            MakeDataBaseFile();
            LoadUsers();
            _settingsRepository = new SettingsRepository(ConnectionString);
            if (!users.Any())
            {
                // Если нет пользователей, создаем Admin (пароль 'admin')
                AddUser("admin", "admin", new Dictionary<int, MenuState>());
            }
        }

        // Создает директорию и файл, если таковых нет
        private void MakeDataBaseFile()
        {
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\..\\"));
            string dbFilePath = Path.Combine(projectRootPath, RelativeDbPath, DatabaseFileName);

            string folder = Path.GetDirectoryName(dbFilePath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            ConnectionString = $"Data Source={dbFilePath}";

            EnsureDatabaseSchema();
        }

        // Создаем таблицу в файле 
        private void EnsureDatabaseSchema()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS MenuItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ParentId INTEGER,
                        MenuName TEXT NOT NULL,
                        DllName TEXT,
                        FunctionName TEXT,
                        SortOrder INTEGER NOT NULL,
                        FOREIGN KEY (ParentId) REFERENCES MenuItems(Id) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS UserRoots (
                        User_Id INTEGER NOT NULL,
                        Menu_id INTEGER NOT NULL,
                        R INTEGER DEFAULT 0,
                        W INTEGER DEFAULT 0,
                        E INTEGER DEFAULT 0,
                        D INTEGER DEFAULT 0,
                        PRIMARY KEY (User_Id, Menu_id),
                        FOREIGN KEY (User_Id) REFERENCES Users(Id) ON DELETE CASCADE,
                        FOREIGN KEY (Menu_id) REFERENCES MenuItems(Id) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();

                command.CommandText = $@"
                    CREATE TABLE IF NOT EXISTS UserSettings (
                        id_user INTEGER PRIMARY KEY,
                        font_family TEXT NOT NULL,
                        font_size INTEGER NOT NULL,
                        FOREIGN KEY (id_user) REFERENCES Users(Id) ON DELETE CASCADE
                    );";
                command.ExecuteNonQuery();
            }
        }

        // Метод для загрузки данных пользователей из файла
        private void LoadUsers()
        {
            users.Clear();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Username, Password FROM Users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        string passwordHash = reader.GetString(2);

                        User currUser = new User { Id = id, UserName = username, Password = passwordHash };
                        users[username] = currUser;

                        var command_get_roots = connection.CreateCommand();
                        command_get_roots.CommandText = @"
                            SELECT 
                                Menu_id, 
                                R, W, E, D 
                            FROM UserRoots 
                            WHERE User_Id = @id";
                        command_get_roots.Parameters.AddWithValue("@id", id);
                        using (var reader_roots = command_get_roots.ExecuteReader())
                        {
                            while (reader_roots.Read())
                            {
                                int menu = reader_roots.GetInt32(0);
                                int r = reader_roots.GetInt32(1);
                                int w = reader_roots.GetInt32(2);
                                int e = reader_roots.GetInt32(3);
                                int d = reader_roots.GetInt32(4);

                                currUser.MenuStatus[menu] = new MenuState() { R = r, W = w, E = e, D = d };
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создает SHA256 хеш для переданной строки.
        /// </summary>
        /// <param name="password">Пароль в виде открытого текста.</param>
        /// <returns>Хеш-строка в формате Base64.</returns>
        private string HashPassword(string password)
        {
            // Используем SHA256 для хеширования
            using (var sha256 = SHA256.Create())
            {
                // Преобразуем строку в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                // Вычисляем хеш
                byte[] hash = sha256.ComputeHash(bytes);
                // Возвращаем хеш в виде Base64 строки для хранения в БД
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Метод для проверки логина и пароля
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            if (users.TryGetValue(username, out var userData))
            {
                // 1. Хешируем введенный пользователем пароль
                string enteredPasswordHash = HashPassword(password);

                // 2. Сравниваем полученный хеш с хешем, хранящимся в памяти (который был загружен из БД)
                if (enteredPasswordHash == userData.Password)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Добавляет нового пользователя в БД.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="password">Пароль в виде открытого текста.</param>
        /// <param name="menuStates">Словарь прав доступа.</param>
        /// <returns>True, если пользователь успешно добавлен, иначе False.</returns>
        public bool AddUser(string username, string password, Dictionary<int, MenuState> menuStates)
        {
            if (users.ContainsKey(username))
            {
                // Пользователь с таким именем уже существует
                return false;
            }

            // Хешируем пароль перед записью в БД
            string hashedPassword = HashPassword(password);
            long newUserId;

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // 1. Добавляем пользователя
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Users (Username, Password) VALUES (@user, @hash); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@hash", hashedPassword);

                    // Получаем ID только что вставленной строки
                    newUserId = (long)command.ExecuteScalar();
                }

                // 2. Добавляем права доступа (UserRoots)
                if (newUserId > 0)
                {
                    SetUserRights((int)newUserId, menuStates, connection);
                }
            }

            // 3. Обновляем словарь в памяти
            User newUser = new User
            {
                Id = (int)newUserId,
                UserName = username,
                Password = hashedPassword,
                MenuStatus = menuStates
            };
            users[username] = newUser;

            // 4. Сохраняем настройки пользователя в таблицу
            _settingsRepository.SaveSettings((int)newUserId);

            return true;
        }

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="newPassword">Новый пароль в виде открытого текста.</param>
        /// <returns>True, если пароль успешно изменен, иначе False.</returns>
        public bool ChangePassword(string username, string newPassword)
        {
            if (!users.TryGetValue(username, out var userData))
            {
                return false; // Пользователь не найден
            }

            // Хешируем новый пароль
            string newHashedPassword = HashPassword(newPassword);

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Users SET Password = @newHash WHERE Id = @id";
                    command.Parameters.AddWithValue("@newHash", newHashedPassword);
                    command.Parameters.AddWithValue("@id", userData.Id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        // Обновляем данные в словаре в памяти
                        userData.Password = newHashedPassword;
                        users[username] = userData;
                        return true;
                    }
                    return false;
                }
            }
        }

        public bool ChangePasswordSafe(string username, string oldPassword, string newPassword)
        {
            if (!users.TryGetValue(username, out var userData))
            {
                return false; // Пользователь не найден
            }
            if (Authenticate(username, oldPassword) == false) throw new ArgumentException("Неверный старый пароль. Повторите попытку");

            // Хешируем новый пароль
            string newHashedPassword = HashPassword(newPassword);

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Users SET Password = @newHash WHERE Id = @id";
                    command.Parameters.AddWithValue("@newHash", newHashedPassword);
                    command.Parameters.AddWithValue("@id", userData.Id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        // Обновляем данные в словаре в памяти
                        userData.Password = newHashedPassword;
                        users[username] = userData;
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Задает или обновляет права доступа для пользователя.
        /// Переименован в EditUserRights для ясности.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="menuStates">Словарь прав доступа.</param>
        public bool EditUserRights(string username, Dictionary<int, MenuState> menuStates)
        {
            if (!users.TryGetValue(username, out var userData))
            {
                return false; // Пользователь не найден
            }

            // Внутренний метод SetUserRights теперь использует userId
            SetUserRights(userData.Id, menuStates);
            return true;
        }

        /// <summary>
        /// Удаляет пользователя из системы.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>True, если пользователь удален, иначе False.</returns>
        public bool RemoveUser(string username)
        {
            if (!users.TryGetValue(username, out var userData))
            {
                return false; // Пользователь не найден
            }

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    // 1. Удаляем пользователя из таблицы Users. 
                    // Благодаря FOREIGN KEY ON DELETE CASCADE, его права из UserRoots удалятся автоматически.
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "DELETE FROM Users WHERE Id = @id";
                        command.Parameters.AddWithValue("@id", userData.Id);

                        if (command.ExecuteNonQuery() > 0)
                        {
                            transaction.Commit();

                            // 2. Удаляем из словаря в памяти
                            users.Remove(username);
                            return true;
                        }
                        // Если удаление из Users не удалось, откатываем транзакцию (хотя ExecuteNonQuery() == 0)
                        return false;
                    }
                }
            }
        }

        // ==========================================
        // МЕТОДЫ ПРОСМОТРА (READ)
        // ==========================================

        /// <summary>
        /// Получает объект пользователя по имени.
        /// </summary>
        public User GetUser(string username)
        {
            if (users.TryGetValue(username, out var userData))
            {
                return userData;
            }
            return null;
        }

        /// <summary>
        /// Возвращает список всех пользователей.
        /// </summary>
        public List<User> GetAllUsers()
        {
            return users.Values.ToList();
        }

        /// <summary>
        /// Задает или обновляет права доступа для пользователя.
        /// </summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="menuStates">Словарь прав доступа.</param>
        /// <param name="connection">Существующее соединение (опционально).</param>
        public void SetUserRights(int userId, Dictionary<int, MenuState> menuStates, SqliteConnection connection = null)
        {
            bool closeConnection = connection == null;
            if (connection == null)
            {
                connection = new SqliteConnection(ConnectionString);
                connection.Open();
            }

            using (var transaction = connection.BeginTransaction())
            {
                // 1. Удаляем все старые права пользователя
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "DELETE FROM UserRoots WHERE User_Id = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }

                // 2. Добавляем новые права
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
                        INSERT INTO UserRoots (User_Id, Menu_id, R, W, E, D) 
                        VALUES (@userId, @menuId, @r, @w, @e, @d)";

                    command.Parameters.Add("@userId", SqliteType.Integer).Value = userId;
                    command.Parameters.Add("@menuId", SqliteType.Integer);
                    command.Parameters.Add("@r", SqliteType.Integer);
                    command.Parameters.Add("@w", SqliteType.Integer);
                    command.Parameters.Add("@e", SqliteType.Integer);
                    command.Parameters.Add("@d", SqliteType.Integer);

                    foreach (var kvp in menuStates)
                    {
                        command.Parameters["@menuId"].Value = kvp.Key;
                        command.Parameters["@r"].Value = kvp.Value.R;
                        command.Parameters["@w"].Value = kvp.Value.W;
                        command.Parameters["@e"].Value = kvp.Value.E;
                        command.Parameters["@d"].Value = kvp.Value.D;
                        command.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }

            if (closeConnection)
            {
                connection.Close();
            }

            // Обновляем права в словаре в памяти, если пользователь уже загружен
            if (users.Any(u => u.Value.Id == userId))
            {
                var userEntry = users.First(u => u.Value.Id == userId);
                userEntry.Value.MenuStatus = menuStates;
            }
        }
    }

    public static class AuthorizationInterface
    {
        public static void Run(Authorization authManager)
        {
            while (true)
            {
                Console.WriteLine("\n=== УПРАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯМИ ===");
                Console.WriteLine("1. Просмотр всех пользователей");
                Console.WriteLine("2. Добавить пользователя");
                Console.WriteLine("3. Изменить пароль");
                Console.WriteLine("4. Удалить пользователя");
                Console.WriteLine("5. Установить права доступа (MenuStatus)");
                Console.WriteLine("0. Назад/Выход");
                Console.Write("Выбор: ");

                var key = Console.ReadLine();

                try
                {
                    switch (key)
                    {
                        case "1":
                            ShowAllUsers(authManager);
                            break;
                        case "2":
                            DoAddUser(authManager);
                            break;
                        case "3":
                            DoChangePassword(authManager);
                            break;
                        case "4":
                            DoRemoveUser(authManager);
                            break;
                        case "5":
                            DoEditRights(authManager);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        private static void ShowAllUsers(Authorization authManager)
        {
            Console.WriteLine("\n--- СПИСОК ПОЛЬЗОВАТЕЛЕЙ ---");
            var allUsers = authManager.GetAllUsers();

            if (!allUsers.Any())
            {
                Console.WriteLine("Нет зарегистрированных пользователей.");
                return;
            }

            foreach (var user in allUsers)
            {
                Console.WriteLine($"ID: {user.Id}, Имя: {user.UserName}, Хеш пароля: {user.Password.Substring(0, 10)}...");

                if (user.MenuStatus.Any())
                {
                    Console.WriteLine("  Права доступа (MenuID | R/W/E/D):");
                    foreach (var status in user.MenuStatus)
                    {
                        Console.WriteLine($"    {status.Key}: {status.Value.R}/{status.Value.W}/{status.Value.E}/{status.Value.D}");
                    }
                }
                else
                {
                    Console.WriteLine("  Права доступа не установлены.");
                }
            }
        }

        private static void DoAddUser(Authorization authManager)
        {
            Console.Write("Введите имя нового пользователя: ");
            string user = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();

            // По умолчанию новый пользователь получает пустые права
            if (authManager.AddUser(user, pass, new Dictionary<int, MenuState>()))
            {
                Console.WriteLine($"Пользователь '{user}' успешно добавлен (ID: {authManager.GetUser(user)?.Id}).");
            }
            else
            {
                Console.WriteLine($"Ошибка: Пользователь с именем '{user}' уже существует.");
            }
        }

        private static void DoChangePassword(Authorization authManager)
        {
            Console.Write("Введите имя пользователя для изменения пароля: ");
            string user = Console.ReadLine();
            Console.Write("Введите новый пароль: ");
            string newPass = Console.ReadLine();

            if (authManager.ChangePassword(user, newPass))
            {
                Console.WriteLine($"Пароль для пользователя '{user}' успешно изменен.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Пользователь '{user}' не найден.");
            }
        }

        private static void DoRemoveUser(Authorization authManager)
        {
            Console.Write("Введите имя пользователя для удаления: ");
            string user = Console.ReadLine();

            if (user.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Невозможно удалить пользователя 'admin'.");
                return;
            }

            if (authManager.RemoveUser(user))
            {
                Console.WriteLine($"Пользователь '{user}' успешно удален.");
            }
            else
            {
                Console.WriteLine($"Ошибка: Пользователь '{user}' не найден.");
            }
        }

        private static void DoEditRights(Authorization authManager)
        {
            Console.Write("Введите имя пользователя для установки прав: ");
            string user = Console.ReadLine();
            var userData = authManager.GetUser(user);

            if (userData == null)
            {
                Console.WriteLine($"Пользователь '{user}' не найден.");
                return;
            }

            Console.Write("Введите ID меню, для которого устанавливаются права (или 0 для отмены): ");
            if (!int.TryParse(Console.ReadLine(), out int menuId) || menuId == 0) return;

            // Создаем новый словарь прав, копируя старые, если они есть
            var newStates = new Dictionary<int, MenuState>(userData.MenuStatus);
            MenuState currentState;

            // Пытаемся получить существующие права. Если не нашли, используем новые пустые MenuState.
            if (newStates.TryGetValue(menuId, out MenuState existingState))
            {
                currentState = existingState;
            }
            else
            {
                currentState = new MenuState();
            }

            Console.WriteLine($"Текущие права для MenuID {menuId}: R={currentState.R}, W={currentState.W}, E={currentState.E}, D={currentState.D}");

            Console.Write("Новое значение R (1/0, enter чтобы оставить): ");
            if (int.TryParse(Console.ReadLine(), out int r)) currentState.R = r;

            Console.Write("Новое значение W (1/0, enter чтобы оставить): ");
            if (int.TryParse(Console.ReadLine(), out int w)) currentState.W = w;

            Console.Write("Новое значение E (1/0, enter чтобы оставить): ");
            if (int.TryParse(Console.ReadLine(), out int e)) currentState.E = e;

            Console.Write("Новое значение D (1/0, enter чтобы оставить): ");
            if (int.TryParse(Console.ReadLine(), out int d)) currentState.D = d;

            newStates[menuId] = currentState;

            if (authManager.EditUserRights(user, newStates))
            {
                Console.WriteLine($"Права для '{user}' успешно обновлены.");
            }
            else
            {
                // Сюда мы, по идее, не попадем, так как проверили пользователя выше
                Console.WriteLine("Неизвестная ошибка при обновлении прав.");
            }
        }
    }
}