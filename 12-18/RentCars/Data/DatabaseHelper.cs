using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentCars
{
    public class DatabaseHelper
    {
        private static string connectionString = "Data Source=rentcars.db;Version=3;FailIfMissing=False;Journal Mode=Wal;Pooling=True;Max Pool Size=100;Default Timeout=30;";

        public static void InitializeDatabase()
        {
            try
            {
                if (!File.Exists("rentcars.db"))
                {
                    SQLiteConnection.CreateFile("rentcars.db");
                    CreateTables();
                    InsertInitialData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации БД: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createCarsTable = @"
                    CREATE TABLE IF NOT EXISTS Cars (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Status INTEGER NOT NULL,
                        PricePerDay REAL NOT NULL,
                        Class TEXT NOT NULL
                    )";

                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Role TEXT NOT NULL
                    )";

                string createRentalsTable = @"
                    CREATE TABLE IF NOT EXISTS Rentals (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CarName TEXT NOT NULL,
                        CustomerName TEXT NOT NULL,
                        RentalDate TEXT NOT NULL,
                        Days INTEGER NOT NULL,
                        TotalPrice REAL NOT NULL,
                        IsActive INTEGER NOT NULL
                    )";

                using (var command = new SQLiteCommand(createCarsTable, connection))
                    command.ExecuteNonQuery();

                using (var command = new SQLiteCommand(createUsersTable, connection))
                    command.ExecuteNonQuery();

                using (var command = new SQLiteCommand(createRentalsTable, connection))
                    command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private static void InsertInitialData()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Проверяем, есть ли уже данные
                string checkQuery = "SELECT COUNT(*) FROM Cars";
                using (var checkCmd = new SQLiteCommand(checkQuery, connection))
                {
                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        connection.Close();
                        return;
                    }
                }

                // Добавляем машины
                string insertCars = @"
                    INSERT INTO Cars (Name, Status, PricePerDay, Class) VALUES
                    ('Toyota Camry', 1, 50, 'Бизнес'),
                    ('BMW X5', 0, 80, 'Люкс'),
                    ('Hyundai Solaris', 1, 40, 'Эконом'),
                    ('Mercedes E-Class', 1, 70, 'Бизнес'),
                    ('Volkswagen Polo Mk2', 0, 45, 'Эконом')";

                using (var command = new SQLiteCommand(insertCars, connection))
                    command.ExecuteNonQuery();

                // Добавляем админа
                string insertAdmin = @"
                    INSERT INTO Users (Username, PasswordHash, Role) VALUES
                    ('admin', @password, 'Менеджер')";

                using (var command = new SQLiteCommand(insertAdmin, connection))
                {
                    command.Parameters.AddWithValue("@password", HashPassword("123"));
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Методы для работы с машинами
        public static async Task<List<Car>> GetAllCarsAsync()
        {
            var cars = new List<Car>();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    string query = "SELECT * FROM Cars";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            cars.Add(new Car
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Status = reader.GetInt32(2) == 1,
                                PricePerDay = reader.GetDouble(3),
                                Class = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки машин: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return cars;
        }

        public static async Task UpdateCarAsync(Car car)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    string query = "UPDATE Cars SET Status = @status WHERE Id = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", car.Status ? 1 : 0);
                        command.Parameters.AddWithValue("@id", car.Id);
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления машины: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Методы для работы с пользователями
        public static async Task<UserModel> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    string query = "SELECT * FROM Users WHERE Username = @username";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                var user = new UserModel
                                {
                                    Id = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    PasswordHash = reader.GetString(2),
                                    Role = reader.GetString(3)
                                };

                                if (user.PasswordHash == HashPassword(password))
                                    return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка аутентификации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public static async Task<bool> RegisterUserAsync(string username, string password, string role)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @password, @role)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", HashPassword(password));
                        command.Parameters.AddWithValue("@role", role);
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Метод для сохранения аренды
        public static async Task SaveRentalAsync(RentalModel rental)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    string query = @"
                        INSERT INTO Rentals (CarName, CustomerName, RentalDate, Days, TotalPrice, IsActive) 
                        VALUES (@carName, @customerName, @date, @days, @price, @isActive)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@carName", rental.CarName);
                        command.Parameters.AddWithValue("@customerName", rental.CustomerName);
                        command.Parameters.AddWithValue("@date", rental.RentalDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@days", rental.Days);
                        command.Parameters.AddWithValue("@price", rental.TotalPrice);
                        command.Parameters.AddWithValue("@isActive", rental.IsActive ? 1 : 0);
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения аренды: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}