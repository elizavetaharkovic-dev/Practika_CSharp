class ServerShutdownManager
{
    public event EventHandler ServerShuttingDown;
    public void Shutdown()
    {
        Console.WriteLine("Сервер выключается...");
        ServerShuttingDown(this, EventArgs.Empty);
    }
}