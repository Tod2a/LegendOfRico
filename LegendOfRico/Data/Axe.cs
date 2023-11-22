namespace LegendOfRico.Data
{
    public class Axe : Weapon
    {
        public override TypeOfWeapon WeaponType { get; } = TypeOfWeapon.Axe;
        public TypeOfDamage WeaponTypeDamage = TypeOfDamage.Slashing;
    }
}
