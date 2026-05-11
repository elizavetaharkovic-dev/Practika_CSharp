public class WarriorBuilder : ICharacterBuilder
{
    private Character _character = new Character();
    public WarriorBuilder()
    {
        _character.Class = "Воин";
        _character.Health = 150;
        _character.Mana = 0;
        _character.Strength = 20;
        _character.Agility = 10;
        _character.Intelligence = 5;
    }
    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }
    public ICharacterBuilder SetHealth(int health)
    {
        _character.Health = health;
        return this;
    }
    public ICharacterBuilder SetMana(int mana)
    {
        _character.Mana = mana;
        return this;
    }
    public ICharacterBuilder SetStrength(int strength)
    {
        _character.Strength = strength;
        return this;
    }
    public ICharacterBuilder SetAgility(int agility)
    {
        _character.Agility = agility;
        return this;
    }
    public ICharacterBuilder SetIntelligence(int intelligence)
    {
        _character.Intelligence = intelligence;
        return this;
    }
    public Character Build()
    {
        return _character;
    }
}