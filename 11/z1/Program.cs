// Реализация паттерна "Фабричный метод". Оружие (меч, лук, арбалет).
class Program
{
    static void Main()
    {
        List<WeaponFactory> factories = new List<WeaponFactory>
        {
            new SwordFactory(),
            new BowFactory(),
            new CrossbowFactory()
        };

        foreach (var factory in factories)
        {
            IWeapon weapon = factory.CreateWeapon();
            weapon.Attack();
        }
    }
}