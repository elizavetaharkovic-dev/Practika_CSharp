// Обобщенная система уведомлений
class Program
{
    static void Main()
    {
        NotifierManager<string> manager = new NotifierManager<string>();

        EmailNotifier<string> email1 = new EmailNotifier<string>();
        EmailNotifier<string> email2 = new EmailNotifier<string>();

        manager.AddNotifier(email1);
        manager.AddNotifier(email2);

        NotificationService<string> service = new NotificationService<string>(manager);

        service.ShowAllNotifiers();

        string[] messages = { "Привет!", "Как дела?", "До свидания!" };
        string[] recipients = { "alice@mail.com", "bob@mail.com" };

        service.SendBulk(messages, recipients);

        Console.WriteLine("\n=== Удаляем email2 ===");
        manager.RemoveNotifier(email2);
        service.ShowAllNotifiers();

        service.SendBulk(new[] { "Тест после удаления" }, new[] { "test@mail.com" });
    }
}