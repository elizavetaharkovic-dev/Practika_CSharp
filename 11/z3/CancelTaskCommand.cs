public class CancelTaskCommand : ICommand
{
    private TaskScheduler _scheduler;
    private string _taskName;
    public CancelTaskCommand(TaskScheduler scheduler, string taskName)
    {
        _scheduler = scheduler;
        _taskName = taskName;
    }
    public void Execute()
    {
        _scheduler.CancelTask(_taskName);
    }
}