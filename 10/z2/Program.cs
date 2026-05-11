// Создание игрового персонажа
class Program
{
    static void Main()
    {
        CharacterDirector director = new CharacterDirector(new WarriorBuilder());
        Character warrior = director.CreateDefaultCharacter("Алексей");
        warrior.ShowInfo();

        director.SetBuilder(new MageBuilder());
        Character mage = director.CreateDefaultCharacter("Мерлин");
        mage.ShowInfo();

        director.SetBuilder(new ArcherBuilder());
        Character archer = director.CreateCustomCharacter("Леголас", 120, 60, 15, 25, 12);
        archer.ShowInfo();
    }
}