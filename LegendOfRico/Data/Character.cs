using System.ComponentModel;

namespace LegendOfRico.Data;

public abstract class Character : INotifyPropertyChanged
{
    public string Name { get; set; }
    public int Level { get; private set; } = 1;
    public abstract int MaxHitPoints { get; }
    public int CurrentHitPoints { get; private set; }
    public Dictionary<Stats, int> Statistics { get; private set; }
    public int ArmorAmount { get; private set; }
    public Weapon CharacterWeapon { get; private set; }
    public Shield CharacterShield { get; private set; }
    public Armor CharacterArmor { get; private set; }
    public List<Item> Inventory { get; private set; }
    public abstract Boolean CanEquipShield { get; protected set; }
    public int Coins { get; private set; }
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
    private int positionI = 250; 

    public int PositionI
    {
        get { return positionI; }
        private set
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
        private set
        {
            if (value != positionJ)
            {
                positionJ = value;
                OnPropertyChanged(nameof(PositionJ));
            }
        }
    }

    public void CreateCharacter()
    {
        //To be defined
    }

    public virtual void Hit(Monster target)
    {
        int weaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
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
        CharacterShield = new FistShield();
    }

    public void EquipWeapon(Weapon weapon)
    {
        Inventory.Remove(weapon);
        CharacterWeapon = weapon;
    }

    public void UnequipWeapon()
    {
        Inventory.Add(CharacterWeapon);
        CharacterWeapon = new Fist();
    }
    
    public void EquipArmor(Armor armor)
    {
        CharacterArmor = armor;
        Inventory.Remove(armor);
        ArmorAmount += armor.ArmorOfArmor;
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

    public void UnequipArmor()
    {
        Inventory.Add(CharacterArmor);
        ArmorAmount -= CharacterArmor.ArmorOfArmor;
        CharacterArmor = null;
    }

    public void GoUp()
    {
        if (PositionI > 0)
        {
            PositionI--;
        }
    }

    public void GoDown()
    {
        if (PositionI < 499)
        {
            PositionI++;
        }
    }

    public void GoLeft()
    {
        if (PositionJ > 0)
        {
            PositionJ--;
        }
    }

    public void GoRight()
    {
        if (PositionJ < 499)
        {
            PositionJ++;
        }
    }

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}