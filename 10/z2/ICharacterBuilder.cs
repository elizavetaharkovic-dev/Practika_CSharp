public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetHealth(int health);
    ICharacterBuilder SetMana(int mana);
    ICharacterBuilder SetStrength(int strength);
    ICharacterBuilder SetAgility(int agility);
    ICharacterBuilder SetIntelligence(int intelligence);
    Character Build();
}