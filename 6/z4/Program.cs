// Завершение работы сервера
class Program
{
    static void Main()
    {
        ServerShutdownManager manager = new ServerShutdownManager();
        Subscribers subs = new Subscribers();
        ShutdownMonitor monitor = new ShutdownMonitor(manager, subs);

        manager.Shutdown();
    }
}