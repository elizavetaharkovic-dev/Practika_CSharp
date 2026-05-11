public class CrossbowFactory : WeaponFactory
{
    public override IWeapon CreateWeapon()
    {
        return new Crossbow();
    }
}