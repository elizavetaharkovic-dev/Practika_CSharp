using System.Windows;
using System.Windows.Controls;

namespace RentCars
{
    public partial class LoginWindow : Window
    {
        private UserManager _userManager = new UserManager();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e) // получает логин и пароль
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            var user = await _userManager.AuthenticateAsync(username, password); // проверяет бд

            if (user != null)   // закрывает окно аутентификации и переходит на окно брони
            {
                StatusText.Text = "Успешный вход!";
                MainWindow mainWindow = new MainWindow();
                mainWindow.CurrentUser = user;
                mainWindow.Show(); 
                this.Close();
            }
            else
            {
                StatusText.Text = "Ошибка: неверный логин или пароль";
            }
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)   // проверяет заполненность полей
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            string role = (RoleCombo.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Клиент";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                StatusText.Text = "Заполните логин и пароль";
                return;
            }

            if (await _userManager.RegisterAsync(username, password, role))   // добавляет пользователя в БД
            {
                StatusText.Text = "Регистрация успешна! Теперь войдите.";
            }
            else
            {
                StatusText.Text = "Пользователь уже существует";
            }
        }
    }
}