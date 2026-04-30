// Обобщенная система уведомлений
class Program
{
    static void Main()
    {
        NotifierManager<string> manager = new NotifierManager<string>();

        // 2. Создаём отправителей (EmailNotifier)
        EmailNotifier<string> email1 = new EmailNotifier<string>();
        EmailNotifier<string> email2 = new EmailNotifier<string>();

        // 3. Добавляем отправителей в хранилище
        manager.AddNotifier(email1);
        manager.AddNotifier(email2);

        // 4. Создаём бизнес-логику, передаём в неё хранилище
        NotificationService<string> service = new NotificationService<string>(manager);

        // 5. Показываем сколько отправителей
        service.ShowAllNotifiers();

        // 6. Готовим сообщения и получателей
        string[] messages = { "Привет!", "Как дела?", "До свидания!" };
        string[] recipients = { "alice@mail.com", "bob@mail.com" };

        // 7. МАССОВАЯ РАССЫЛКА (главное действие)
        service.SendBulk(messages, recipients);

        // 8. Удаляем одного отправителя
        Console.WriteLine("\n=== Удаляем email2 ===");
        manager.RemoveNotifier(email2);
        service.ShowAllNotifiers();

        // 9. Ещё одна рассылка (уже с одним отправителем)
        service.SendBulk(new[] { "Тест после удаления" }, new[] { "test@mail.com" });
    }
}