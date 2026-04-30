class NotificationService<T>
{
    private NotifierManager<T> _manager;
    public NotificationService(NotifierManager<T> manager)
    {
        _manager = manager;
    }
    public void SendBulk(IEnumerable<T> messages, string[] recipients)
    {
        foreach (var recipient in recipients)
        {
            Console.WriteLine($"\n--- Отправка получателю: {recipient} ---");

            foreach (var message in messages)
            {
                foreach (var notifier in _manager.GetAllNotifiers())
                {
                    notifier.Notify(message);
                }
            }
        }
    }
    public void ShowAllNotifiers()
    {
        Console.WriteLine($"\nОтправителей в хранилище: {_manager.GetAllNotifiers().Count}");
    }
}