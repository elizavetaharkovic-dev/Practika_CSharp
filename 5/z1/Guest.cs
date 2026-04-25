class Guest : User
{
    public Guest(string name) : base(name) { }
    public override void GetPermissions()
    {
        Console.WriteLine($"Права доступа {Name}: только чтение (только смотрит, не может ничего сделать).");
    }
}