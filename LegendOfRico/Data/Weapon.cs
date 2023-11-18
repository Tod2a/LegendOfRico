namespace DefaultNamespace;

public abstract class Weapon : Item
{
    public TypeOfWeapon WeaponType { get; private set; }
    public Dictionary<Stats, int> BonusStats { get; private set; }

}