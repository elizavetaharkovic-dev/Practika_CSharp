using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RentCars
{
    public class ChatService
    {
        private NamedPipeServerStream _server;
        private NamedPipeClientStream _client;
        private bool _isServer;
        private Dispatcher _uiDispatcher;

        public event Action<string> MessageReceived;

        public ChatService(Dispatcher uiDispatcher, bool isServer)
        {
            _uiDispatcher = uiDispatcher;
            _isServer = isServer;
        }

        public async Task StartServerAsync()  //Создает сервер, ждет подключения
        {
            _server = new NamedPipeServerStream("CarRentalChat", PipeDirection.InOut);
            await _server.WaitForConnectionAsync();
            _ = Task.Run(ListenForMessagesAsync);
        }

        public async Task ConnectClientAsync()  //Подключается к серверу
        {
            _client = new NamedPipeClientStream(".", "CarRentalChat", PipeDirection.InOut);
            await _client.ConnectAsync();
            _ = Task.Run(ListenForClientMessagesAsync);
        }

        public async Task SendMessageAsync(string message)  // Отправляет сообщение (в зависимости от роли)
        {
            if (_isServer && _server != null && _server.IsConnected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _server.WriteAsync(buffer, 0, buffer.Length);
            }
            else if (!_isServer && _client != null && _client.IsConnected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _client.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        private async Task ListenForMessagesAsync()  // Сервер слушает входящие
        {
            byte[] buffer = new byte[1024];
            while (_server != null && _server.IsConnected)
            {
                int bytesRead = await _server.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    _uiDispatcher.Invoke(() => MessageReceived?.Invoke(message));
                }
            }
        }

        private async Task ListenForClientMessagesAsync()  // Клиент слушает входящие
        {
            byte[] buffer = new byte[1024];
            while (_client != null && _client.IsConnected)
            {
                int bytesRead = await _client.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    _uiDispatcher.Invoke(() => MessageReceived?.Invoke(message));
                }
            }
        }
    }
}