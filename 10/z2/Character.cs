public class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Персонаж: {Name}");
        Console.WriteLine($"Класс: {Class}");
        Console.WriteLine($"Здоровье: {Health}");
        Console.WriteLine($"Мана: {Mana}");
        Console.WriteLine($"Сила: {Strength}");
        Console.WriteLine($"Ловкость: {Agility}");
        Console.WriteLine($"Интеллект: {Intelligence}");
        Console.WriteLine();
    }
}