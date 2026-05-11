public class TaskScheduler
{
    public void StartTask(string taskName)
    {
        Console.WriteLine($"Задача '{taskName}' запущена.");
    }
    public void CancelTask(string taskName)
    {
        Console.WriteLine($"Задача '{taskName}' отменена.");
    }
}