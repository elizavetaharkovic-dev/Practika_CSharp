class Subscribers
{
    public void BackupService(object sender, EventArgs e)
    {
        Console.WriteLine("Создано резервное копирование!");
    }

    public void AlertSystem(object sender, EventArgs e)
    {
        Console.WriteLine("Оповещён администратор");
    }
}