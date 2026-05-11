public class CharacterDirector
{
    private ICharacterBuilder _builder;
    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }
    public void SetBuilder(ICharacterBuilder builder)
    {
        _builder = builder;
    }
    public Character CreateDefaultCharacter(string name)
    {
        return _builder
            .SetName(name)
            .Build();
    }
    public Character CreateCustomCharacter(string name, int health, int mana,
        int strength, int agility, int intelligence)
    {
        return _builder
            .SetName(name)
            .SetHealth(health)
            .SetMana(mana)
            .SetStrength(strength)
            .SetAgility(agility)
            .SetIntelligence(intelligence)
            .Build();
    }
}