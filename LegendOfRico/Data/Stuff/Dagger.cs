
namespace LegendOfRico.Data;

public class Dagger : Weapon
{
    public Dagger(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) : 
        base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
    {
    }

    public Dagger(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
        base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage)
    {
    }

    public override TypeOfWeapon WeaponType => TypeOfWeapon.Dagger;
    public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Piercing;
    public override double WeaponCritChance => 0.2;
}