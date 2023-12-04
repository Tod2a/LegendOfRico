
namespace LegendOfRico.Data;

public class Fist : Weapon
{
    public Fist(string itemName, string description,int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) : 
        base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
    {
    }

    public override TypeOfWeapon WeaponType => TypeOfWeapon.None;
    public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Bludgeoning;
    public override double WeaponCritChance => 0;
}