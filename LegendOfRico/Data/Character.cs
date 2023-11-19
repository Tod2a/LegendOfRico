namespace LegendOfRico.Data;

public abstract class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; } = 1;
    public int MaxHitPoints { get; private set; }
    public int CurrentHitPoints { get; private set; }
    public Dictionary<Stats, int> Statistics { get; private set; }
    public int ArmorAmount { get; private set; }
    public Weapon CharacterWeapon { get; private set; }
    public Armor CharacterArmor { get; private set; }
    public Item[] Inventory { get; private set; }
    public abstract TypeOfWeapon[] WeaponMastery { get; }
    public abstract TypeOfArmor ArmorMastery { get; }

    public void CreateCharacter()
    {
        //To be defined
    }

    public void Hit(Monster target)
    {
        int WeaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        if ((new Random()).NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            WeaponDamageRoll *= 2;
        }
        target.TakeDamage(WeaponDamageRoll);
    }

    public void ReceiveHeal(int HealAmount)
    {
        if (CurrentHitPoints + HealAmount > MaxHitPoints)
        {
            CurrentHitPoints = MaxHitPoints;
        }
        else
        {
            CurrentHitPoints += HealAmount;
        }
    }
}