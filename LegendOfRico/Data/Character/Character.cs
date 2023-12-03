using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace LegendOfRico.Data;

public abstract class Character : INotifyPropertyChanged
{
    public string Name { get; set; }
    private int level = 1;
    public int Level {
        get { return level; }
        set 
        {
            if (level != value)
            {
                level = value;
                CheckLearnSpell();
            }
        } 
    }
    public int CurrentXp { get; set; } = 0;
    public int XpToLevel { get; set; } = 1000;
    public abstract int MaxHitPoints { get; }
    public abstract int CurrentHitPoints { get; protected set; }
    public int Statistics { get; private set; }
    public abstract int ArmorAmount { get; protected set; }
    public abstract double ChanceToDodge { get; protected set; }
    public abstract Weapon CharacterWeapon { get; protected set; }
    public abstract Shield CharacterShield { get; protected set; }
    public Armor CharacterArmor { get; private set; }
    public abstract List<Spells> SpellBook { get; protected set; }
    public List<Item> Inventory { get; private set; }
    public List<Quest> quests { get; private set; }
    public abstract Boolean CanEquipShield { get; protected set; }
    public int Coins { get; private set; }
    public virtual string fightImgUrl { get; }
    private string mapSprite;
    public string MapSprite
    {
        get { return mapSprite; }
        set
        {
            if (mapSprite != value)
            {
                mapSprite = value;
                OnPropertyChanged(nameof(MapSprite));
            }
        }
    }
    public abstract TypeOfWeapon[] WeaponMastery { get; }
    public abstract TypeOfArmor ArmorMastery { get; }
    public int lastRestVillageI { get; set; } = 250;
    public int LastRestVillageJ { get; set; } = 250;
    private int positionI = 250;
    public Boolean IsFrozen { get; private set; } = false;
    public Boolean IsBurning { get; private set; } = false;

    public int PositionI
    {
        get { return positionI; }
        set
        {
            if (value != positionI)
            {
                positionI = value;
                OnPropertyChanged(nameof(PositionI));
            }
        }
    }
    private int positionJ = 250; 

    public int PositionJ
    {
        get { return positionJ; }
        set
        {
            if (value != positionJ)
            {
                positionJ = value;
                OnPropertyChanged(nameof(PositionJ));
            }
        }
    }


    protected abstract void CheckLearnSpell();
    public void Burnt()
    {
        IsBurning = true;
    }

    public void Frozen()
    {
        IsFrozen = true;
    }

    public void Rest()
    {
        lastRestVillageI = positionI;
        LastRestVillageJ = positionJ;
        CurrentHitPoints = MaxHitPoints;
        foreach (var spell in SpellBook)
        {
            spell.RefreshSpell();
        }
    }

    public virtual void Hit(Monster target)
    {
        int weaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        weaponDamageRoll += (int)((Statistics / 50) * weaponDamageRoll);

        if ((new Random()).NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            weaponDamageRoll *= 2;
        }

        if (target.MonsterWeakness.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll *= 2;
        }
        target.TakeDamage(weaponDamageRoll);
    }

    public void ReceiveHeal(int healAmount)
    {
        if (CurrentHitPoints + healAmount > MaxHitPoints)
        {
            CurrentHitPoints = MaxHitPoints;
        }
        else
        {
            CurrentHitPoints += healAmount;
        }
    }

    public string TakeDamage(int damageTaken)
    {
        if (damageTaken > ArmorAmount)
        { 
            CurrentHitPoints -= damageTaken - ArmorAmount;
        }
        return " et vous inflige " + damageTaken + " dégats réduit par votre armure de " + ArmorAmount;
    }

    public void EquipShield(Shield shield)
    {
        CharacterShield = shield;
        Inventory.Remove(shield);
        ArmorAmount += shield.ShieldBonusArmor;
    }

    public void UnequipShield()
    {
        Inventory.Add(CharacterShield);
        ArmorAmount -= CharacterShield.ShieldBonusArmor;
        CharacterShield = new FistShield("Poing",0,0);
    }

    public void EquipWeapon(Weapon weapon)
    {
        Inventory.Remove(weapon);
        CharacterWeapon = weapon;
    }

    public void UnequipWeapon()
    {
        Inventory.Add(CharacterWeapon);
        CharacterWeapon = new Fist("Poing", 0, 1, 3);
    }
    
    public void EquipArmor(Armor armor)
    {
        CharacterArmor = armor;
        Inventory.Remove(armor);
        ArmorAmount += armor.ArmorOfArmor;
    }
    public void UnequipArmor()
    {
        Inventory.Add(CharacterArmor);
        ArmorAmount -= CharacterArmor.ArmorOfArmor;
        CharacterArmor = new Topless();
    }

    public void LootItem(Item droppedItem)
    {
        Inventory.Add(droppedItem);
    }

    public void LootGold(int droppedGold)
    {
        Coins += droppedGold;
    }

    public void Sell(Item soldItem)
    {
        Inventory.Remove(soldItem);
        Coins += (int)(soldItem.Price) / 4;
    }

    public void Buy(Item boughtItem)
    {
        if (boughtItem.Price <= Coins)
        {
            Coins -= boughtItem.Price;
            Inventory.Add(boughtItem);
        }
        else
        {
            //To be defined
        }
    }

    

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}