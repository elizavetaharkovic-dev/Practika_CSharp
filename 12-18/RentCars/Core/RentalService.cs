using System.Threading.Tasks;
using System.Windows;

namespace RentCars
{
    public class RentalService
    {
        // Асинхронная обработка заявки на бронирование (имитация)
        public async Task<bool> ProcessRentalAsync(Car car, int days, string customerName)
        {
            // Имитация длительной обработки (4 секунды)
            await Task.Delay(4000);

            // Все проверки уже сделаны в ExecuteBookCar
            return true;
        }

        // Подтверждение бронирования (обновление статуса)
        public void ConfirmRental(Car car, int days, double total)
        {
            car.Status = false;
            MessageBox.Show($"Вы арендовали {car.Name} на {days} дней.\nСтоимость: {total} руб", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}