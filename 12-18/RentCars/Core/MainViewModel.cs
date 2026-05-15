using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RentCars 
{
    public class MainViewModel : INotifyPropertyChanged     // вся логика тут
    {
        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(TotalPrice));
                // Обновляем состояние команд при изменении выбранной машины
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private int _rentalDays;
        public int RentalDays
        {
            get => _rentalDays;
            set
            {
                _rentalDays = value;
                OnPropertyChanged(nameof(RentalDays));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ICommand BookCarCommand { get; set; }
        public ICommand EditBookingCommand { get; set; }
        public ICommand CancelBookingCommand { get; set; }
        public ICommand OpenChatCommand { get; set; }

        public ObservableCollection<Car> AllCars { get; set; }
        public ObservableCollection<string> CarClasses { get; set; }

        private string _selectedCarClass;
        public string SelectedCarClass
        {
            get => _selectedCarClass;
            set
            {
                _selectedCarClass = value;
                OnPropertyChanged(nameof(SelectedCarClass));
                ApplyFilter();
            }
        }

        private bool _showOnlyAvailable;
        public bool ShowOnlyAvailable
        {
            get => _showOnlyAvailable;
            set
            {
                _showOnlyAvailable = value;
                OnPropertyChanged(nameof(ShowOnlyAvailable));
                ApplyFilter();
            }
        }

        public double TotalPrice
        {
            get
            {
                // Проверяем, что SelectedCar не null
                if (SelectedCar != null)
                {
                    return RentalDays * SelectedCar.PricePerDay;
                }
                return 0;
            }
        }

        private bool _isProcessing;  // Блокировка кнопок во время операции
        public bool IsProcessing
        {
            get => _isProcessing;
            set
            {
                _isProcessing = value;
                OnPropertyChanged(nameof(IsProcessing));
            }
        }

        private string _processingStatus;
        public string ProcessingStatus
        {
            get => _processingStatus;
            set
            {
                _processingStatus = value;
                OnPropertyChanged(nameof(ProcessingStatus));
            }
        }

        public MainViewModel(UserModel currentUser)
        {
            CurrentUser = currentUser;

            OpenChatCommand = new RelayCommand(ExecuteOpenChat);
            CarClasses = new ObservableCollection<string> { "Все", "Эконом", "Бизнес", "Люкс" };
            SelectedCarClass = "Все";
            RentalDays = 1;

            BookCarCommand = new RelayCommand(ExecuteBookCar, CanExecuteBookCar);
            EditBookingCommand = new RelayCommand(ExecuteEditBooking, CanExecuteEditBooking);
            CancelBookingCommand = new RelayCommand(ExecuteCancelBooking, CanExecuteCancelBooking);

            // Инициализируем пустыми коллекциями
            AllCars = new ObservableCollection<Car>();
            Cars = new ObservableCollection<Car>();

            // Устанавливаем SelectedCar в null явно
            _selectedCar = null;
        }

        public async Task LoadCarsAsync() // загружает машины из бд
        {
            try
            {
                var cars = await DatabaseHelper.GetAllCarsAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    AllCars.Clear();
                    Cars.Clear();

                    foreach (var car in cars)
                    {
                        AllCars.Add(car);
                        Cars.Add(car);
                    }

                    OnPropertyChanged(nameof(Cars));

                    // Сбрасываем выбранную машину после загрузки
                    SelectedCar = null;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки машин: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilter()   // фильтрует список машин
        {
            if (AllCars == null || AllCars.Count == 0) return;

            try
            {
                IEnumerable<Car> filtered = AllCars;

                if (SelectedCarClass != "Все" && !string.IsNullOrEmpty(SelectedCarClass))
                    filtered = filtered.Where(c => c.Class == SelectedCarClass);

                if (ShowOnlyAvailable)
                    filtered = filtered.Where(c => c.Status == true);

                Cars.Clear();
                foreach (var car in filtered)
                {
                    Cars.Add(car);
                }
                OnPropertyChanged(nameof(Cars));

                // Если выбранная машина больше не в списке, сбрасываем выбор
                if (SelectedCar != null && !Cars.Contains(SelectedCar))
                {
                    SelectedCar = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanExecuteBookCar(object parameter)
        {
            return SelectedCar != null && SelectedCar.Status && !IsProcessing;
        }

        private async void ExecuteBookCar(object parameter)   // бронирование
        {
            if (SelectedCar == null)
            {
                MessageBox.Show("Выберите автомобиль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!SelectedCar.Status)
            {
                MessageBox.Show("Машина уже арендована", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string customerName = CurrentUser?.Username ?? "Клиент";

            IsProcessing = true;
            ProcessingStatus = "Обрабатывается...";

            // Блокируем кнопки
            CommandManager.InvalidateRequerySuggested();

            try
            {
                await Task.Delay(4000);

                // Сохраняем копию выбранной машины
                var carToRent = SelectedCar;

                // Обновляем статус машины в БД
                carToRent.Status = false;
                await DatabaseHelper.UpdateCarAsync(carToRent);

                // Сохраняем информацию об аренде
                var rental = new RentalModel
                {
                    CarName = carToRent.Name,
                    CustomerName = customerName,
                    RentalDate = DateTime.Now,
                    Days = RentalDays,
                    TotalPrice = RentalDays * carToRent.PricePerDay,
                    IsActive = true
                };

                await DatabaseHelper.SaveRentalAsync(rental);

                MessageBox.Show($"Вы арендовали {carToRent.Name} на {RentalDays} дней.\nСтоимость: {RentalDays * carToRent.PricePerDay} руб",
                    "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                // Обновляем список машин
                await LoadCarsAsync();
                ApplyFilter();
                OnPropertyChanged(nameof(TotalPrice));

                // Отправляем уведомление
                NotificationService.SendNotification($"Новое бронирование: {carToRent.Name} на {RentalDays} дней. Стоимость: {RentalDays * carToRent.PricePerDay} руб");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при бронировании: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsProcessing = false;
                ProcessingStatus = "";
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private bool CanExecuteEditBooking(object parameter)
        {
            return SelectedCar != null && !SelectedCar.Status && !IsProcessing;
        }

        private void ExecuteEditBooking(object parameter)
        {
            MessageBox.Show("Функция редактирования брони в разработке", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanExecuteCancelBooking(object parameter)
        {
            return SelectedCar != null && !SelectedCar.Status && !IsProcessing;
        }

        private async void ExecuteCancelBooking(object parameter)
        {
            if (SelectedCar == null)
            {
                MessageBox.Show("Выберите автомобиль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите отменить бронь автомобиля {SelectedCar.Name}?",
                "Подтверждение отмены",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                IsProcessing = true;
                ProcessingStatus = "Отмена брони...";
                CommandManager.InvalidateRequerySuggested();

                try
                {
                    // Сохраняем копию выбранной машины
                    var carToCancel = SelectedCar;

                    // Обновляем статус машины в БД
                    carToCancel.Status = true;
                    await DatabaseHelper.UpdateCarAsync(carToCancel);

                    MessageBox.Show($"Бронь автомобиля {carToCancel.Name} отменена.", "Отменено", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Обновляем список машин
                    await LoadCarsAsync();
                    ApplyFilter();
                    OnPropertyChanged(nameof(TotalPrice));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отмене брони: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsProcessing = false;
                    ProcessingStatus = "";
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        private void ExecuteOpenChat(object parameter)
        {
            string role = CurrentUser?.Role ?? "Клиент";
            ChatWindow chatWindow = new ChatWindow(role);
            chatWindow.Owner = Application.Current.MainWindow;
            chatWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}