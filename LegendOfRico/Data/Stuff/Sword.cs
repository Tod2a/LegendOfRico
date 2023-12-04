
namespace LegendOfRico.Data;

public class Sword : Weapon
{
    public Sword(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
    {
    }

    public Sword(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
        base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage)
    {
    }

    public override TypeOfWeapon WeaponType => TypeOfWeapon.Sword;
    public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
    public override double WeaponCritChance => 0.10;
}