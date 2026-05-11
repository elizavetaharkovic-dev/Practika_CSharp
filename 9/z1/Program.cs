// Основные операции с файлами
class Program
{
    static void Main()
    {
        FileManager manager = new FileManager();
        string fileText = manager.FileCreate("Привет. Это пробник для выполнения задания по практике. Данная тема: Работа с файлами.");
        Console.WriteLine("Содержимое файла 1:\n" + fileText);
        manager.FileCopy();
        manager.FileMoveTo();
        manager.FileDelete();
        string file2 = manager.FileCreate("Для удаления");
        Console.WriteLine("\nСодержимое файла 2:\n" + file2);
        manager.FileDelete();  
        string file3 = manager.FileCreate("Для проверки переименования файла");
        Console.WriteLine("\nСодержимое файла 3:\n" + file3);
        manager.FileRename();
        manager.FileCompare();
        File.Create(@"D:\Practika_CSharp\9\z1\bin\Debug\net8.0\Сopies\jbgp.ea").Close();
        File.Create(@"D:\Practika_CSharp\9\z1\bin\Debug\net8.0\Сopies\jgmjv.ea").Close();
        File.Create(@"D:\Practika_CSharp\9\z1\bin\Debug\net8.0\Сopies\hello.ea").Close();
        File.Create(@"D:\Practika_CSharp\9\z1\bin\Debug\net8.0\Сopies\hi.txt").Close();
        File.Create(@"D:\Practika_CSharp\9\z1\bin\Debug\net8.0\Сopies\hi.bebe").Close();
        manager.FileDeleteByPattern();
        string[] listFiles = manager.ListAllFilesInDirectory();
        Console.WriteLine("\nВ папке:\n" + string.Join("\n", listFiles));
        Console.WriteLine("\nИнформация о файле kharkovich.ea:");
        FileInfoProvider info = new FileInfoProvider();
        info.GetFileInfo();
        info.SetReadOnly();
        manager.FileWrite("ща проверим");
        info.CheckFilePermissions();
        new FileInfo("kharkovich.ea").IsReadOnly = false;
        Console.WriteLine("\nЕсли в данный момент вы хотите посмотреть то что создали не закрывайте программу. \n" +
            "После просмотра ОБЯЗАТЕЛЬНО нажмите любую клавишу для завершения программы. \n" +
            "Нажмите любую клавишу для очистки папки.");
        Console.ReadKey();
        manager.DeleteAll();
    }
}