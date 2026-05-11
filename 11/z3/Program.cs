// Реализация паттерна "Команда". Планировщик задач – запуск и отмена задач.
using System.Windows.Input;

class Program
{
    static void Main()
    {
        TaskScheduler scheduler = new TaskScheduler();
        SchedulerController controller = new SchedulerController();

        ICommand startTask = new StartTaskCommand(scheduler, "Резервное копирование");
        ICommand cancelTask = new CancelTaskCommand(scheduler, "Резервное копирование");

        controller.SetCommand(startTask);
        controller.PressButton();

        controller.SetCommand(cancelTask);
        controller.PressButton();
    }
}