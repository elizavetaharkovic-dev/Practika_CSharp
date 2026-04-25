class Moderator : User
{
    public Moderator(string name) : base(name) { }
    public override void GetPermissions()
    {
        Console.WriteLine($"Права доступа {Name}: следит за порядком, но не может менять настройки (удаляет спам, блокирует нарушителей).");
    }
}
