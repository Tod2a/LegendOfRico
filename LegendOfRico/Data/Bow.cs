namespace LegendOfRico.Data
{
    public class Bow : Weapon
    {
        public override TypeOfWeapon WeaponType => TypeOfWeapon.Bow;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Piercing;
    }
}
