// Уведомление при изменении больших файлов
class Program
{
    static void Main()
    {
        FileWatcher fileWatcher = new FileWatcher();
        fileWatcher.Start(@"D:\Practika_CSharp\9\z4\bin\Debug\net8.0");
        Console.WriteLine("Слежение запущено. Нажмите Enter для выхода...");
        Console.ReadKey();
        fileWatcher.Stop();
    }
}