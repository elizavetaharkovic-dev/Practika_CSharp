public class MageBuilder : ICharacterBuilder
{
    private Character _character = new Character();
    public MageBuilder()
    {
        _character.Class = "Маг";
        _character.Health = 80;
        _character.Mana = 200;
        _character.Strength = 5;
        _character.Agility = 8;
        _character.Intelligence = 25;
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