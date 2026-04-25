class GameCharacter
{
    public string Name {  get; set; }
    public int Health {  get; set; }
    public GameCharacter(string name)
    { 
        Name = name;
        Health = 100;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} получил {damage} урона. Осталось здоровья: {Health}");
    }
}