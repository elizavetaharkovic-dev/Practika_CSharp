using System.Windows;
using System.Windows.Threading;

namespace RentCars
{
    public partial class ChatWindow : Window
    {
        private ChatService _chatService;
        private string _role;

        public ChatWindow(string role)
        {
            InitializeComponent();
            _role = role;
            Loaded += ChatWindow_Loaded;
        }

        private async void ChatWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool isServer = (_role == "Менеджер");
            _chatService = new ChatService(Dispatcher, isServer);
            _chatService.MessageReceived += OnMessageReceived;

            if (isServer)
                await _chatService.StartServerAsync();
            else
                await _chatService.ConnectClientAsync();
        }

        private void OnMessageReceived(string message)
        {
            Dispatcher.Invoke(() =>
            {
                MessagesList.Items.Add(message);
                if (MessagesList.Items.Count > 0)
                    MessagesList.ScrollIntoView(MessagesList.Items[MessagesList.Items.Count - 1]);
            });
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageBox.Text))
            {
                string message = $"{_role}: {MessageBox.Text}";
                await _chatService.SendMessageAsync(message);
                MessagesList.Items.Add(message);
                MessageBox.Clear();
            }
        }
    }
}