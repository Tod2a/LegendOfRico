namespace LegendOfRico.Data;

public abstract class Weapon : Item
{
    public abstract double WeaponCritChance { get; }
    public int MinimumWeaponDamage { get; protected set; }
    public int MaximumWeaponDamage { get; protected set; }
    public abstract TypeOfWeapon WeaponType { get; }
    public abstract TypeOfDamage WeaponTypeOfDamage { get;}
    public Dictionary<Stats, int> BonusStats { get; protected set; }

    public Weapon(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, Dictionary<Stats, int> bonusStats) {
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