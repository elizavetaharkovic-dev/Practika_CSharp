// Ошибка при отправке email-сообщения
class Program
{
    static void Main()
    {
        EmailManager manager = new EmailManager();
        try
        {
            manager.SendMessage("elioinc@apihnev");
        }
        catch (EmailSendingException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
            Console.WriteLine($"Внутренняя ошибка: {ex.InnerException?.Message}");
        }

    }
}