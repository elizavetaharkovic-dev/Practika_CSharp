// Глобальный идентификатор пользователей (UserIDGenerator)
class Program
{
    static void Main()
    {
        UserIDGenerator generator1 = UserIDGenerator.Instance;
        UserIDGenerator generator2 = UserIDGenerator.Instance;

        Console.WriteLine(generator1.GenerateID());
        Console.WriteLine(generator1.GenerateID());
        Console.WriteLine(generator2.GenerateID());
        Console.WriteLine(generator2.GenerateID());

        Console.WriteLine(generator1 == generator2);
    }
}