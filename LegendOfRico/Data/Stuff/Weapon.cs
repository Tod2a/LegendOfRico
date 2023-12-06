
namespace LegendOfRico.Data;

public abstract class Weapon : Stuff
{
    public override double WeaponCritChance { get; protected set; }
    public override int MinimumWeaponDamage { get; protected set; }
    public override int MaximumWeaponDamage { get; protected set; }
    public override string Description {  get;  set; }
    public override TypeOfStuff TypeOfStuff { get; protected set; } = TypeOfStuff.Weapon;
    public abstract TypeOfWeapon WeaponType { get; }
    public override TypeOfDamage WeaponTypeOfDamage { get;}
    public override int BonusStats { get; protected set; }

    public Weapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) {
        ItemName = itemName;
        Description = description;
        Price = price;
        MinimumWeaponDamage = minimumWeaponDamage;
        MaximumWeaponDamage = maximumWeaponDamage;
        BonusStats = bonusStats;
    }
}