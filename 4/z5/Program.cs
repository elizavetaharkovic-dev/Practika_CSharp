// Создайте абстрактный класс Game с абстрактным методом Play() и виртуальным методом DisplayRules().
class Program
{
    static void Main()
    {
        Game game1 = new Chess();
        game1.Play();
        game1.DisplayRules();

        Console.WriteLine("\n");

        Game game2 = new Checkers();
        game2.Play();
        game2.DisplayRules();
    }
}
