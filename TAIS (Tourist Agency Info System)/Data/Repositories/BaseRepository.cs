using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace TAIS__Tourist_Agency_Info_System_.Data.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        // Имя файла БД
        protected static string DatabaseFileName = "tais.db";

        // Относительный путь от корня проекта до папки с файлами БД
        protected static string RelativeDbPath = Path.Combine("Data", "DataFiles");

        protected static string ConnectionString;
        private static bool _schemaChecked = false;

        static BaseRepository()
        {
            if (!_schemaChecked)
            {
                string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRootPath = Path.GetFullPath(Path.Combine(appBaseDirectory, "..\\..\\..\\..\\"));
                string dbFolder = Path.Combine(projectRootPath, RelativeDbPath);
                if (!Directory.Exists(dbFolder))
                {
                    Directory.CreateDirectory(dbFolder);
                }

                string dbFilePath = Path.Combine(dbFolder, DatabaseFileName);
                ConnectionString = $"Data Source={dbFilePath}";

                EnsureDatabaseSchema();

                _schemaChecked = true;
            }
        }

        protected SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "PRAGMA foreign_keys = ON;";
            command.ExecuteNonQuery();
            return connection;
        }

        public List<string> SqlCommand(string query)
        {
            var result = new List<string>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = query;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var rowValues = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString();
                    rowValues.Add(value);
                }
                result.Add(string.Join(" | ", rowValues));
            }
            return result;
        }

        public int ExecuteNonQuery(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL не должен быть пустым", nameof(sql));

            using var conn = GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }

        public async Task<int> ExecuteNonQueryAsync(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL не должен быть пустым", nameof(sql));

            await using var conn = GetConnection();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            return await cmd.ExecuteNonQueryAsync();
        }

        private static void EnsureDatabaseSchema()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();

            // Создание таблиц в порядке, учитывающем внешние ключи

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Country (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS City (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL,

                    -- Внешние ключи
                    CountryId INTEGER NOT NULL,
                    FOREIGN KEY (CountryId) REFERENCES Country(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Street (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS AircraftType (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Carrier (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Voyage (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Внешние ключи
                    CarrierId INTEGER NOT NULL,
                    AircraftTypeId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (CarrierId) REFERENCES Carrier(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (AircraftTypeId) REFERENCES AircraftType(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Flight (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Дата/время
                    DepartureDate TEXT NOT NULL,
                    DepartureTime TEXT NOT NULL,

                    -- Внешние ключи
                    VoyageId INTEGER NOT NULL,
                    FOREIGN KEY (VoyageId) REFERENCES Voyage(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Position (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Title TEXT NOT NULL,
                    OkpdtrCode TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE ""Employee"" (
	                ""Id""	INTEGER,
	                ""StreetId""	INTEGER NOT NULL,
	                ""FirstName""	TEXT NOT NULL,
	                ""MiddleName""	TEXT,
	                ""LastName""	TEXT NOT NULL,
	                ""BirthDate""	TEXT NOT NULL,
	                ""Gender""	TEXT NOT NULL,
	                ""WorkExperience""	REAL NOT NULL,
	                ""PositionId""	INTEGER NOT NULL DEFAULT 1,
	                PRIMARY KEY(""Id"" AUTOINCREMENT),
	                FOREIGN KEY(""PositionId"") REFERENCES ""Position""(""Id"") ON DELETE RESTRICT,
	                FOREIGN KEY(""StreetId"") REFERENCES ""Street""(""Id"") ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Route (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL,
                    Duration INTEGER NOT NULL,

                    -- Внешние ключи
                    CountryId INTEGER NOT NULL,
                    CreatedByEmployeeId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (CountryId) REFERENCES Country(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (CreatedByEmployeeId) REFERENCES Employee(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Hotel (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Поля
                    Name TEXT NOT NULL,
                    Stars INTEGER NOT NULL,

                    -- Внешние ключи
                    CityId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (CityId) REFERENCES City(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS RoutePoint (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Порядковый номер / срок пребывания
                    SequenceNumber INTEGER NOT NULL,
                    StayDuration INTEGER NOT NULL,
                    ExcursionProgram TEXT NOT NULL,

                    -- Внешние ключи
                    RouteId INTEGER NOT NULL,
                    CityId INTEGER NOT NULL,
                    HotelId INTEGER NOT NULL,
                    CreatedByEmployeeId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (RouteId) REFERENCES Route(Id) ON DELETE CASCADE,
                    FOREIGN KEY (CityId) REFERENCES City(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (HotelId) REFERENCES Hotel(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (CreatedByEmployeeId) REFERENCES Employee(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Trip (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Даты
                    DepartureDate TEXT NOT NULL,
                    ArrivalDate TEXT NOT NULL,

                    -- Финансы
                    TripCost REAL NOT NULL,
                    Penalty REAL NOT NULL,

                    -- Внешние ключи
                    RouteId INTEGER NOT NULL,
                    RepresentativeEmployeeId INTEGER NOT NULL,
                    OutboundFlightId INTEGER NOT NULL,
                    ReturnFlightId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (RouteId) REFERENCES Route(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (RepresentativeEmployeeId) REFERENCES Employee(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (OutboundFlightId) REFERENCES Flight(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (ReturnFlightId) REFERENCES Flight(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Client (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Личная информация
                    FirstName TEXT NOT NULL,
                    MiddleName TEXT,
                    LastName TEXT NOT NULL,
                    BirthDate TEXT NOT NULL,
                    Gender TEXT NOT NULL,

                    -- Паспортные данные
                    PassportSeries TEXT NOT NULL,
                    PassportNumber TEXT NOT NULL,
                    PassportIssueDate TEXT NOT NULL,
                    PassportIssuedBy TEXT NOT NULL,

                    -- Контакт
                    Phone TEXT NOT NULL
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Child (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Личная информация
                    FirstName TEXT NOT NULL,
                    MiddleName TEXT,
                    LastName TEXT NOT NULL,
                    BirthDate TEXT NOT NULL,
                    Gender TEXT NOT NULL,

                    -- Внешние ключи
                    ClientId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (ClientId) REFERENCES Client(Id) ON DELETE CASCADE
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Данные заказа
                    OrderDate TEXT NOT NULL,
                    OrderTime TEXT NOT NULL,

                    -- Внешние ключи
                    ClientId INTEGER NOT NULL,
                    TripId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (ClientId) REFERENCES Client(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (TripId) REFERENCES Trip(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Ticket (
                    -- Первичный ключ
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    -- Информация о билете
                    TicketClass TEXT NOT NULL,
                    SeatNumber TEXT NOT NULL,
                    Price REAL NOT NULL,

                    -- Внешние ключи
                    ClientId INTEGER NOT NULL,
                    FlightId INTEGER NOT NULL,

                    -- Ограничения
                    FOREIGN KEY (ClientId) REFERENCES Client(Id) ON DELETE RESTRICT,
                    FOREIGN KEY (FlightId) REFERENCES Flight(Id) ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE ""HREvent"" (
	                ""Id""	INTEGER,
	                ""EventDate""	TEXT NOT NULL,
	                ""EventType""	TEXT NOT NULL,
	                ""Profession""	TEXT NOT NULL,
	                ""Department""	TEXT NOT NULL,
	                ""DocumentType""	TEXT NOT NULL,
	                ""Reason""	TEXT NOT NULL,
	                ""WorkPlaceStreetId""	INTEGER NOT NULL,
	                ""PositionId""	INTEGER NOT NULL,
	                ""EmployeeId""	INTEGER NOT NULL,
	                ""OrganizationName""	TEXT,
	                PRIMARY KEY(""Id"" AUTOINCREMENT),
	                FOREIGN KEY(""EmployeeId"") REFERENCES ""Employee""(""Id"") ON DELETE CASCADE,
	                FOREIGN KEY(""PositionId"") REFERENCES ""Position""(""Id"") ON DELETE RESTRICT,
	                FOREIGN KEY(""WorkPlaceStreetId"") REFERENCES ""Street""(""Id"") ON DELETE RESTRICT
                );";
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            // Nothing to dispose in base now; concrete repos may implement
        }
    }
}
