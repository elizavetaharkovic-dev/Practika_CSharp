using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace RentCars
{
    public class NotificationService
    {
        private const string MMFName = "CarRentalNotifications";
        private Dispatcher _uiDispatcher;
        private bool _isRunning;
        private Thread _listenerThread;

        public event Action<string> NotificationReceived;

        public NotificationService(Dispatcher uiDispatcher)
        {
            _uiDispatcher = uiDispatcher;
        }

        public void StartListening()  // прием
        {
            _isRunning = true;
            _listenerThread = new Thread(ListenForNotifications);
            _listenerThread.IsBackground = true;
            _listenerThread.Start();
        }

        private void ListenForNotifications()
        {
            while (_isRunning)
            {
                try
                {
                    using (var mmf = MemoryMappedFile.OpenExisting(MMFName))
                    using (var accessor = mmf.CreateViewAccessor())
                    {
                        byte[] buffer = new byte[4096];
                        accessor.ReadArray(0, buffer, 0, buffer.Length);
                        string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                        if (!string.IsNullOrEmpty(message))
                        {
                            _uiDispatcher.Invoke(() => NotificationReceived?.Invoke(message));
                            // Очищаем после прочтения
                            byte[] empty = new byte[4096];
                            accessor.WriteArray(0, empty, 0, empty.Length);
                        }
                    }
                }
                catch
                {
                    // Канал ещё не создан — игнорируем
                }
                Thread.Sleep(1000);
            }
        }

        public static void SendNotification(string message) // отправка 
        {
            try
            {
                using (var mmf = MemoryMappedFile.CreateOrOpen(MMFName, 4096))
                using (var accessor = mmf.CreateViewAccessor())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(message.PadRight(4096, '\0'));
                    accessor.WriteArray(0, bytes, 0, bytes.Length);
                }
            }
            catch
            {
                // Игнорируем ошибки отправки
            }
        }

        public void StopListening()
        {
            _isRunning = false;
        }
    }
}