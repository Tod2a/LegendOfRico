namespace LegendOfRico.Data
{
    public class Bow : Weapon
    {
        public override TypeOfWeapon WeaponType { get; } = TypeOfWeapon.Bow;
        public TypeOfDamage WeaponTypeDamage = TypeOfDamage.Piercing;
    }
}
