public class StartTaskCommand : ICommand
{
    private TaskScheduler _scheduler;
    private string _taskName;
    public StartTaskCommand(TaskScheduler scheduler, string taskName)
    {
        _scheduler = scheduler;
        _taskName = taskName;
    }
    public void Execute()
    {
        _scheduler.StartTask(_taskName);
    }
}