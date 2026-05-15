using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RentCars
{
    public partial class MainWindow : Window
    {
        private NotificationService _notificationService;
        public UserModel CurrentUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Загружаем данные после загрузки окна
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем ViewModel
                var viewModel = new MainViewModel(CurrentUser);

                // Загружаем данные
                await viewModel.LoadCarsAsync();

                // Устанавливаем DataContext
                DataContext = viewModel;

                // Запускаем сервис уведомлений
                _notificationService = new NotificationService(Dispatcher);
                _notificationService.NotificationReceived += OnNotificationReceived;
                _notificationService.StartListening();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnNotificationReceived(string message) // показывает всплывающее сообщение при бронировании
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(message, "Новое уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)  // закрывает приложение
        {
            _notificationService?.StopListening();
            this.Close();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)  // инфо о программе
        {
            MessageBox.Show("Приложение для аренды автомобилей\nВерсия 1.0", "О программе");
        }

        private void CarListBox_Loaded(object sender, RoutedEventArgs e)   // анимация появления каждого элемента списка с задержкой 0.1с
        {
            var listBox = sender as ListBox;
            if (listBox == null) return;

            var baseStoryboard = this.Resources["FadeInScaleAnimation"] as Storyboard;
            if (baseStoryboard == null) return;

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var container = listBox.ItemContainerGenerator.ContainerFromIndex(i) as FrameworkElement;
                if (container != null)
                {
                    container.Opacity = 0;
                    container.RenderTransform = new ScaleTransform(0.8, 0.8);
                    container.RenderTransformOrigin = new Point(0.5, 0.5);

                    var sb = baseStoryboard.Clone();

                    var beginTime = TimeSpan.FromSeconds(i * 0.5);
                    foreach (var timeline in sb.Children)
                    {
                        timeline.BeginTime = beginTime;
                    }

                    sb.Begin(container);
                }
            }
        }
    }
}