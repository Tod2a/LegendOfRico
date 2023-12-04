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
    public abstract int CurrentHitPoints { get; set; }
    public int Statistics { get; private set; }
    public abstract int ArmorAmount { get; protected set; }
    public abstract double ChanceToDodge { get; protected set; }
    public abstract Stuff CharacterWeapon { get; protected set; }
    public abstract Stuff CharacterShield { get; protected set; }
    public abstract Stuff CharacterArmor { get; protected set; }
    public abstract List<Spells> SpellBook { get; protected set; }
    public List<Consumable> ConsumableInventory { get; private set; }
    public List<Stuff> StuffInventory { get; private set; }
    public List<Quest> Quests { get; private set; }
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
    public Character() 
    {
        ConsumableInventory = new List<Consumable>
        {
            new Potion(0, "Potion de départ", 0, 1, 10, 5),
            new Potion(1, "Petite potion de soin", 5, 1, 10, 0),
            new Potion(2, "Potion de soin", 10, 10, 20, 0),
            new Potion(3, "Grande potion de soin", 20, 20, 40, 0),
            new Potion(4, "Enorme potion de soin", 40, 40, 80, 0)
        };
        StuffInventory = new List<Stuff>
        {
            new Mace("Masse de départ", "une masse", 10, 5, 10)
        };
    }
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
        int actualDamageTaken = ArmorAmount > damageTaken ? 0 : damageTaken - ArmorAmount;
        CurrentHitPoints -= actualDamageTaken;
        return " et vous inflige " + actualDamageTaken + " points de dégats (" + damageTaken+" - "+ArmorAmount+").";
    }

    //Gestion des équipements
    public void EquipStuff(Stuff stuff)
    {
        if(stuff.TypeOfStuff == TypeOfStuff.Weapon)
        {
            UnequipWeapon();
            StuffInventory.Remove(stuff);
            CharacterWeapon = stuff;
        }
        else if (stuff.TypeOfStuff == TypeOfStuff.Shield)
        {
            UnequipShield();
            CharacterShield = stuff;
            StuffInventory.Remove(stuff);
            ArmorAmount += stuff.ShieldBonusArmor;
        }
        else if (stuff.TypeOfStuff == TypeOfStuff.Armor)
        {
            UnequipArmor();
            CharacterArmor = stuff;
            StuffInventory.Remove(stuff);
            ArmorAmount += stuff.ArmorOfArmor;
        }
    }

    public void UnequipShield()
    {
        if(!(CharacterShield.GetType() == typeof(FistShield)))
        {
            StuffInventory.Add(CharacterShield);
            ArmorAmount -= CharacterShield.ShieldBonusArmor;
            CharacterShield = new FistShield("Poing", "un poing", 0, 0);
        }
    }

    public void UnequipWeapon()
    {
        if (!(CharacterWeapon.GetType() == typeof(Fist)))
        {
            StuffInventory.Add(CharacterWeapon);
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3);
        }
    }

    public void UnequipArmor()
    {
        if (!(CharacterArmor.GetType() == typeof(Topless)))
        {
            StuffInventory.Add(CharacterArmor);
            ArmorAmount -= CharacterArmor.ArmorOfArmor;
            CharacterArmor = new Topless("Rien", "Bah rien", 0, TypeOfArmor.None, 0); ;
        }
    }

    public void LootStuff(Stuff droppedItem)
    {
        StuffInventory.Add(droppedItem);
    }

    public void LootGold(int droppedGold)
    {
        Coins += droppedGold;
    }

    public void SellStuff(Stuff soldItem)
    {
        StuffInventory.Remove(soldItem);
        Coins += (int)(soldItem.Price) / 4;
    }

    public void BuyStuff(Stuff boughtItem)
    {
        if (boughtItem.Price <= Coins)
        {
            Coins -= boughtItem.Price;
            StuffInventory.Add(boughtItem);
        }
        else
        {
            //To be defined
        }
    }

    public void SellConsumable(Consumable consumable)
    {
        ConsumableInventory[consumable.Id].Quantity--;
        Coins += (int)(consumable.Price) / 4;
    }

    public void BuyConsumable(Consumable boughtConsumable)
    {
        if (boughtConsumable.Price <= Coins)
        {
            Coins -= boughtConsumable.Price;
            ConsumableInventory[boughtConsumable.Id].Quantity++;
        }
    }

    

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}