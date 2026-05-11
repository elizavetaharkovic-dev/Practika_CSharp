class FileWatcher
{
    private FileSystemWatcher watcher;
    public void Start(string path)
    {
        watcher = new FileSystemWatcher(path);
        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;
        watcher.Changed += OnChanged;
        watcher.Renamed += OnRenamed;
        watcher.EnableRaisingEvents = true;
    }
    public void Stop()
    {
        watcher = new FileSystemWatcher();
        watcher.EnableRaisingEvents = false;
    }
    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        string msg = $"{DateTime.Now}: Создан файл - {e.Name}";
        Console.WriteLine(msg);
        File.AppendAllText(@"D:\Practika_CSharp\9\log.txt", msg + "\n");  // ← ЭТО СТРОКА ЛОГИРОВАНИЯ
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        string msg = $"{DateTime.Now}: Удалён файл - {e.Name}";
        Console.WriteLine(msg);
        File.AppendAllText(@"D:\Practika_CSharp\9\log.txt", msg + "\n");
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        string msg = $"{DateTime.Now}: Изменён файл - {e.Name}";
        Console.WriteLine(msg);
        File.AppendAllText(@"D:\Practika_CSharp\9\log.  ", msg + "\n");

        FileInfo info = new FileInfo(e.FullPath);
        if (info.Length > 100 * 1024 * 1024)
        {
            string warning = $"{DateTime.Now}: Файл {e.Name} слишком большой!";
            Console.WriteLine(warning);
            File.AppendAllText(@"D:\Practika_CSharp\9\log.txt", warning + "\n");
        }
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        string msg = $"{DateTime.Now}: Переименован: было - {e.OldName}, стало - {e.Name}";
        Console.WriteLine(msg);
        File.AppendAllText(@"D:\Practika_CSharp\9\log.txt", msg + "\n");
    }
}