namespace LegendOfRico.Data;

public abstract class Weapon : Stuff
{
    public abstract double WeaponCritChance { get; }
    public int MinimumWeaponDamage { get; protected set; }
    public int MaximumWeaponDamage { get; protected set; }
    public abstract TypeOfWeapon WeaponType { get; }
    public abstract TypeOfDamage WeaponTypeOfDamage { get;}
    public int BonusStats { get; protected set; }

    public Weapon(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) {
        ItemName = itemName;
        Price = price;
        MinimumWeaponDamage = minimumWeaponDamage;
        MaximumWeaponDamage = maximumWeaponDamage;
        BonusStats = bonusStats;
    }

    public Weapon(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage)
    {
        ItemName = itemName;
        Price = price;
        MinimumWeaponDamage = minimumWeaponDamage;
        MaximumWeaponDamage = maximumWeaponDamage;
    }
}