
namespace LegendOfRico.Data;

public class Fist : Weapon
{
    public Fist(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) : base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
    {
    }

    public Fist(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, Dictionary<Stats, int> bonusStats) : base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
    {
    }

    public override TypeOfWeapon WeaponType => TypeOfWeapon.None;
    public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Bludgeoning;
    public override double WeaponCritChance => 0;
}