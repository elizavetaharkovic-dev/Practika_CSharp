using System.Windows;

namespace RentCars
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Инициализируем базу данных. создает бд если нету
            DatabaseHelper.InitializeDatabase();
        }
    }
}