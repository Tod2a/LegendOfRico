namespace LegendOfRico.Data;

public class Sword : Weapon
{
    public override TypeOfWeapon WeaponType { get; } = TypeOfWeapon.Sword;
    public TypeOfDamage WeaponTypeOfDamage = TypeOfDamage.Slashing;
}