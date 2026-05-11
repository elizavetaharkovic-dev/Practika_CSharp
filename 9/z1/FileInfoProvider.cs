class FileInfoProvider
{
    private string fileName = "kharkovich.ea";
    public void SetReadOnly()
    {
        new FileInfo(fileName).IsReadOnly = true;
    }
    public void GetFileInfo()
    {
        FileInfo info = new FileInfo(fileName);
        Console.WriteLine($"Размер: {info.Length} байт");
        Console.WriteLine($"Создан: {info.CreationTime}");
        Console.WriteLine($"Изменен: {info.LastWriteTime}");
        Console.WriteLine($"Открыт: {info.LastAccessTime}");
    }
    public void CheckFilePermissions()
    {
        FileInfo info = new FileInfo(fileName);
        Console.WriteLine($"Чтение: {(info.Exists ? "да" : "нет")}");
        Console.WriteLine($"Запись: {(!info.IsReadOnly ? "да" : "нет")}");
        Console.WriteLine($"Выполнение: {(fileName.EndsWith("*.exe") ? "да" : "нет")}");
    }
}