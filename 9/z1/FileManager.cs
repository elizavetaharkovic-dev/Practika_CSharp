class FileManager
{
    private string fileName = "file.txt";
    public string newFileName = "kharkovich.ea";
    public string FileCreate(string text)
    {
        File.WriteAllText(fileName, text);
        string textInFile = File.ReadAllText(fileName);
        return textInFile;
    }
    public void FileDelete()
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.WriteLine("Файл удален");
        }
        else Console.WriteLine($"Файл {fileName} не найден");
    }
    public void FileCopy()
    {
        File.Copy(fileName, "copy.txt");
        if (File.Exists("copy.txt")) Console.WriteLine("Файл успешно скопирован!");
        else Console.WriteLine("Что-то пошло не так...");
    }
    public void FileMoveTo()
    {
        string directoryPath = "Сopies";
        Directory.CreateDirectory(directoryPath);
        string newFilePath = Path.Combine(directoryPath, fileName);
        File.Move(fileName, newFilePath);
        Console.WriteLine("Файл перемещен");
    }
    public void FileRename()
    {
        File.Move(fileName, newFileName);
    }
    public void FileCompare()
    {
        long size1 = new FileInfo("copy.txt").Length;
        long size2 = new FileInfo(newFileName).Length;
        if (size1 == size2) Console.WriteLine("Файлы равны");
        else if (size1 < size2) Console.WriteLine($"Файл {fileName} меньше файла {newFileName}");
        else Console.WriteLine($"Файл {fileName} больше файла {newFileName}");
    }
    public void FileWrite(string text)
    {
        try
        {
            File.WriteAllText(newFileName, text);
            Console.WriteLine("Запись успешна");
        }
        catch
        {
            Console.WriteLine("Запись не удалась");
        }

    }
    public void FileDeleteByPattern()
    {
        string directoryPath = "Сopies";        
        string[] listFiles = Directory.GetFiles(directoryPath, "*.ea");
        foreach (string file in listFiles) File.Delete(file);
    }
    public string[] ListAllFilesInDirectory()
    {
        string[] listFiles = Directory.GetFiles("Сopies");
        return listFiles;
    }
    public void DeleteAll()
    {
        File.Delete(fileName);
        File.Delete(newFileName);
        File.Delete("copy.txt");
        Directory.Delete("Сopies", true);
    }
}