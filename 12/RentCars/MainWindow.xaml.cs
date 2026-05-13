using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentCars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> cars;
        Car selectedCar;
        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
        }
        public void LoadCars()
        {
            cars = new List<Car>();

            cars.Add(new Car { name = "Toyota Camry", status = true, pricePerDay = 50 });
            cars.Add(new Car { name = "BMW X5", status = false, pricePerDay = 80 });
            cars.Add(new Car { name = "Hyundai Solaris", status = true, pricePerDay = 40 });
            cars.Add(new Car { name = "Mercedes E-Class", status = true, pricePerDay = 70 });
            cars.Add(new Car { name = "Volkswagen Polo Mk2", status = false, pricePerDay = 45 });

            CarListBox.ItemsSource = cars;
        }
        public void CarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarListBox.SelectedItem != null) selectedCar = (Car)CarListBox.SelectedItem;
        }
        private void DaysSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DaysLabel == null) return;

            int days = (int)DaysSlider.Value;
            DaysLabel.Content = $"{days} дн.";
        }
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCar == null)
            {
                MessageBox.Show("Выберите машину");
                return;
            }
            if (!selectedCar.status)
            {
                MessageBox.Show("Машина уже арендована");
                return;
            }
            int days = (int)DaysSlider.Value;

            double total = days * selectedCar.pricePerDay;

            selectedCar.status = false;

            CarListBox.ItemsSource = null;
            CarListBox.ItemsSource = cars;

            MessageBox.Show($"Вы арендовали {selectedCar.name} на {days} дней.\nСтоимость: {total} руб");
        }
    }
}