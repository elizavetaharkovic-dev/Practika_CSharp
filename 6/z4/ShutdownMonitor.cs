class ShutdownMonitor
{
    public ShutdownMonitor(ServerShutdownManager manager, Subscribers subs)
    {
        manager.ServerShuttingDown += subs.BackupService;
        manager.ServerShuttingDown += subs.AlertSystem;
    }
}