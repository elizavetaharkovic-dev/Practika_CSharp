class Knight : GameCharacter, IMeleeFighter
{
    public Knight(string name) : base(name) { }
    public void MeleeAttack()
    {
        Console.WriteLine($"{Name} атакует мечом");
    }
}