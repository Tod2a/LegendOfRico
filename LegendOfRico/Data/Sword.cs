namespace LegendOfRico.Data;

public class Sword : Weapon
{
    public override TypeOfWeapon WeaponType => TypeOfWeapon.Sword;
    public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
}