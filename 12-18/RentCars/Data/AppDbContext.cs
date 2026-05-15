using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace RentCars
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rentcars.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка таблицы Cars
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PricePerDay);
                entity.Property(e => e.Class);
                entity.Property(e => e.Status);
            });

            // Настройка таблицы Users
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            });

            // Настройка таблицы Rentals
            modelBuilder.Entity<RentalModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CarName).IsRequired();
                entity.Property(e => e.CustomerName).IsRequired();
                entity.Property(e => e.RentalDate);
                entity.Property(e => e.Days);
                entity.Property(e => e.TotalPrice);
                entity.Property(e => e.IsActive);
            });

            // Добавляем начальные данные
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Toyota Camry", Status = true, PricePerDay = 50, Class = "Бизнес" },
                new Car { Id = 2, Name = "BMW X5", Status = false, PricePerDay = 80, Class = "Люкс" },
                new Car { Id = 3, Name = "Hyundai Solaris", Status = true, PricePerDay = 40, Class = "Эконом" },
                new Car { Id = 4, Name = "Mercedes E-Class", Status = true, PricePerDay = 70, Class = "Бизнес" },
                new Car { Id = 5, Name = "Volkswagen Polo Mk2", Status = false, PricePerDay = 45, Class = "Эконом" }
            );

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Username = "admin", PasswordHash = HashPassword("123"), Role = "Менеджер" }
            );
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return System.Convert.ToBase64String(bytes);
            }
        }
    }
}