using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationLibrary
{
    public class UserSettingsModel
    {
        public string FontFamily { get; set; } = "Segoe UI";
        public int FontSize { get; set; } = 9;

        public Font GetFont()
        {
            try
            {
                return new Font(FontFamily, FontSize, FontStyle.Regular);
            }
            catch
            {
                // Возвращаем шрифт по умолчанию в случае ошибки
                return new Font("Segoe UI", 9, FontStyle.Regular);
            }
        }
    }
    public class SettingsRepository
    {
        private readonly string DatabaseFileName = "Login.db";
        private readonly string RelativeDbPath = Path.Combine("Data", "DataFiles");
        private string ConnectionString;
        public SettingsRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public SettingsRepository()
        {
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\..\\"));
            string dbFilePath = Path.Combine(projectRootPath, RelativeDbPath, DatabaseFileName);

            string folder = Path.GetDirectoryName(dbFilePath);

            ConnectionString = $"Data Source={dbFilePath}";
        }

        /// <summary>
        /// Проверяет наличие файла БД и создает таблицу UserSettings, если ее нет.
        /// </summary>


        /// <summary>
        /// Загружает настройки шрифта для указанного пользователя.
        /// Если настроек нет, возвращает значения по умолчанию.
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Объект UserSettingsModel</returns>
        public Font GetSettings(int userId)
        {
            Font settings = new Font("Segoe UI", 9, FontStyle.Regular); // Настройки по умолчанию
            string sql = "SELECT font_family, font_size FROM UserSettings WHERE id_user = @UserId";

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            settings = new Font(reader["font_family"].ToString(), Convert.ToInt32(reader["font_size"]), FontStyle.Regular);
                            return settings;

                        }
                    }
                }
            }
            return settings;
        }

        /// <summary>
        /// Сохраняет или обновляет настройки шрифта для пользователя.
        /// Использует INSERT OR REPLACE для выполнения UPSERT-операции.
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="fontFamily">Имя шрифта</param>
        /// <param name="fontSize">Размер шрифта</param>
        public void SaveSettings(int userId, string fontFamily = "Segoe UI", int fontSize = 9)
        {
            string sql = @"
                    INSERT OR REPLACE INTO UserSettings (id_user, font_family, font_size)
                    VALUES (@UserId, @FontFamily, @FontSize)";

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@FontFamily", fontFamily);
                    command.Parameters.AddWithValue("@FontSize", fontSize);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void SaveSettings(int userId, Font font)
        {
            string sql = @"
                    INSERT OR REPLACE INTO UserSettings (id_user, font_family, font_size)
                    VALUES (@UserId, @FontFamily, @FontSize)";

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@FontFamily", font.FontFamily.ToString());
                    command.Parameters.AddWithValue("@FontSize", (int)font.Size);

                    command.ExecuteNonQuery();
                }
            }
        }
    }

}