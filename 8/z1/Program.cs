// История выполнения команд в терминале (Stack)
class Program
{
    static void Main()
    {
        TerminalHistory history = new TerminalHistory();
        history.AddCommand("Скопировать файл");
        history.AddCommand("Удалить временные файлы");
        history.AddCommand("Обновить систему");
        history.AddCommand("Перезагрузить сервер");
        history.AddCommand("Распаковать архив");
        history.AddCommand("Распаковать архив");
        Console.WriteLine("--ИСТОРИЯ--");
        history.ShowHistory();
        Console.WriteLine("\n--Поиск команды--");
        if (history.FindCommand("Заархивировать папку") == null)
        {
            Console.WriteLine("Не найдено.");
        }
        else
        {
            Console.Write("Найдено!");
        }
        history.RemoveCommand();
        Console.WriteLine("\n--ИСТОРИЯ--");
        history.ShowHistory();
        history.ClearHistory();
        history.AddCommand("История очищена");
        Console.WriteLine("\n--ИСТОРИЯ--");
        history.ShowHistory();
    }
}