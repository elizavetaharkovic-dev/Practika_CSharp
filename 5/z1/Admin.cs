class Admin: User
{
    public Admin(string name) : base(name) {}
    public override void GetPermissions()
    {
        Console.WriteLine($"Права доступа {Name}: все права (создает, удаляет, назначает права, меняет настройки).");
    }
}