class Archer : GameCharacter, IRangedFighter
{
    public Archer(string name) : base(name) { }
    public void RangedAttack()
    {
        Console.WriteLine($"{Name} стреляет из лука");
    }
}