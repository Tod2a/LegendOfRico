namespace LegendOfRico.Data
{
    public class Mace : Weapon
    {
        public override TypeOfWeapon WeaponType { get; } = TypeOfWeapon.Mace;
        public TypeOfDamage WeaponTypeDamage = TypeOfDamage.Bludgeoning;
    }
}
