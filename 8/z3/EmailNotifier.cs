class EmailNotifier<T> : INotifier<T>
{
    public void Notify(T message)
    {
        Console.WriteLine("Email. Сообщение отправлено: " + message);
    }
}