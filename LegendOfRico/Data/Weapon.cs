namespace LegendOfRico.Data;

public abstract class Weapon : Item
{
    public double WeaponCritChance { get; private set; }
    public int MinimumWeaponDamage { get; private set; }
    public int MaximumWeaponDamage { get; private set; }
    public abstract TypeOfWeapon WeaponType { get; }
    public abstract TypeOfDamage WeaponTypeOfDamage { get; }
    public Dictionary<Stats, int> BonusStats { get; private set; }
}