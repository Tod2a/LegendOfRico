namespace LegendOfRico.Data;

public abstract class Weapon : Stuff
{
    public abstract double WeaponCritChance { get; }
    public int MinimumWeaponDamage { get; protected set; }
    public int MaximumWeaponDamage { get; protected set; }
    public override string Description {  get;  set; }
    public abstract TypeOfWeapon WeaponType { get; }
    public abstract TypeOfDamage WeaponTypeOfDamage { get;}
    public int BonusStats { get; protected set; }

    public Weapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) {
        ItemName = itemName;
        Description = description;
        Price = price;
        MinimumWeaponDamage = minimumWeaponDamage;
        MaximumWeaponDamage = maximumWeaponDamage;
        BonusStats = bonusStats;
    }

    public Weapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage)
    {
        ItemName = itemName;
        Description = description;
        Price = price;
        MinimumWeaponDamage = minimumWeaponDamage;
        MaximumWeaponDamage = maximumWeaponDamage;
    }
}