// Игровые персонажи
class Program
{
    static void Main()
    {
        GameCharacter[] characters = new GameCharacter[]
        {
            new Knight("Артур"),
            new Archer("Робин"),
            new Archer("Леголас"),
            new Knight("Ланселот")        
        };
        Console.WriteLine("Лучники");
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] is IRangedFighter)
            {
                Console.WriteLine($"{characters[i].Name}");
            }
        }
        Console.WriteLine("\nУрон");
        characters[0].TakeDamage(30);
        characters[1].TakeDamage(45);
    } 
}
