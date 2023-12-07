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
    public int RecruitingPrice { get; set; }
    public int CurrentXp { get; set; } = 0;
    public int XpToLevel { get; set; } = 1000;
    public Boolean IsRested { get; private set; } = true;
    public abstract int MaxHitPoints { get; protected set; }
    public abstract int CurrentHitPoints { get; set; }
    public abstract int Statistics { get; set; }
    public abstract int ArmorAmount { get; set; }
    public abstract double ChanceToDodge { get; protected set; }
    public abstract Stuff CharacterWeapon { get; set; }
    public abstract Stuff CharacterShield { get; set; }
    public abstract Stuff CharacterArmor { get; set; }
    public abstract List<Spells> SpellBook { get; protected set; }
    public List<Consumable> ConsumableInventory { get; private set; }
    public List<Stuff> StuffInventory { get; private set; }
    public List<Quest> QuestsBook { get; set; }
    public abstract Boolean CanEquipShield { get; set; }
    public virtual Beast Pet { get; set; } = new Bulldog();
    public int Coins { get; private set; } = 0;
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
    public abstract List<TypeOfWeapon> WeaponMastery { get; }
    public abstract TypeOfArmor ArmorMastery { get; }
    public int lastRestVillageI { get; set; } = 250;
    public int LastRestVillageJ { get; set; } = 250;
    private int positionI = 250;
    public Boolean IsFrozen { get; private set; } = false;
    public Boolean IsBurning { get; private set; } = false;
    public bool Joydead { get; set; } = false;
    public bool Scorpiodead { get; set; } = false;
    public bool Wukongdead { get; set; } = false;
    public bool Tontatondead { get; set; } = false;



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
        StuffInventory = new List<Stuff>{};
        QuestsBook = new List<Quest>
        {
            new FightQuest("La recherche du scorpion éternel", "Le scorpion éternel se cache au find fond du désert éternel, trouvez le et battez le pour récupérer sa relique", TypeOfBreed.EternalScorpio, 1000, 1000),
            new FightQuest("Le mystère du lugubre cimetière", "On entend dire que dans le cimetière des tontaton, leur chef est revenu d'entre les morts et détiendrait une relique", TypeOfBreed.Cheftontaton, 1000, 1000),
            new FightQuest("A travers la forêt de Sherloop", "Se balancant d'arbres en arbres, le grand Sun Wukong nargue tout les voyageurs qu'il rencontre en agitant sa majestueuse relique", TypeOfBreed.Sunwukong, 1000, 1000),
            new FightQuest("Le célèbre Joy Bean", "Joy Bean était connu pour être le roi de la cité la plus riche de l'ancien temps, le grand ricochico l'a asservit et il détient maintenant une relique", TypeOfBreed.Joybean, 1000, 1000),
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
        SetIsRested(true);
    }

    public virtual string Hit(Monster target)
    {
        string s = "";
        int weaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        weaponDamageRoll += (int)((Statistics / 25) * weaponDamageRoll);

        if ((new Random()).NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            weaponDamageRoll *= 2;
            s += "Coup critique ! ";
        }

        if (target.MonsterWeakness.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll *= 2;
            s += "Efficace ! ";
        }
        target.TakeDamage(weaponDamageRoll);
        s += Name+" frappe et inflige " + weaponDamageRoll + " points de dégats ! ";

        SetIsRested(false);
        return s;
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
        return " et inflige " + actualDamageTaken + " points de dégats (" + damageTaken+" - "+ArmorAmount+") à "+Name+" ! ";
    }

    //Gestion des équipements

    public bool CanEquip(Stuff stuff)
    {
        if (stuff.TypeOfStuff == TypeOfStuff.Weapon)
        {
            var WeaponItem = (Weapon)stuff;
            return WeaponMastery.Contains(WeaponItem.WeaponType);
        }
        else if (stuff.TypeOfStuff == TypeOfStuff.Shield)
        {
            return CanEquipShield;
        }
        else if (stuff.TypeOfStuff == TypeOfStuff.Armor)
        {
            var ArmorItem = (Armor)stuff;
            return ArmorMastery >= ArmorItem.ArmorType;
        }
        return false;
    }
    public void EquipStuff(Stuff stuff)
    {
        if(stuff.TypeOfStuff == TypeOfStuff.Weapon) //Si veut équiper une arme
        {
            var stuffWeapon = (Weapon)stuff;
            StuffInventory.Remove(stuff);
            if (this.GetType() == typeof(Rogue) && CharacterWeapon.GetType() != typeof(Fist)) //Si c'est un rogue avec une arme
            {
                if (CharacterWeapon.GetType() != typeof(DoubleWeapon)) //Si pas de main gauche
                {
                    CharacterWeapon = new DoubleWeapon(CharacterWeapon.ItemName + "/" + stuff.ItemName,
                        CharacterWeapon.Description + "/" + stuff.Description,
                        CharacterWeapon.Price + stuff.Price,
                        CharacterWeapon.MinimumWeaponDamage + (stuff.MinimumWeaponDamage / 2),
                        CharacterWeapon.MaximumWeaponDamage + (stuff.MaximumWeaponDamage / 2),
                        CharacterWeapon.BonusStats + stuff.BonusStats,
                        CharacterWeapon, stuff);
                }
                else //Si il a qqch en main gauche
                {
                    var ambidextrWeapon = (DoubleWeapon)CharacterWeapon;
                    Stuff weapon1 = ambidextrWeapon.Weapon1;
                    Stuff weapon2 = ambidextrWeapon.Weapon2;
                    StuffInventory.Add(weapon2);
                    CharacterWeapon = new DoubleWeapon(weapon1.ItemName + "/" + stuff.ItemName,
                        weapon1.Description + "/" + stuff.Description,
                        weapon1.Price + stuff.Price,
                        weapon1.MinimumWeaponDamage + (stuff.MinimumWeaponDamage / 2),
                        weapon1.MaximumWeaponDamage + (stuff.MaximumWeaponDamage / 2),
                        weapon1.BonusStats + stuff.BonusStats,
                        weapon1, stuff);
                }
            }
            else if(stuffWeapon.GetType() == typeof(Greatsword))
            {
                UnequipWeapon();
                UnequipShield();
                CharacterWeapon = stuffWeapon;
                CanEquipShield = false;
            }
            else
            {
                UnequipWeapon();
                CharacterWeapon = stuff;
            }
            Statistics += CharacterWeapon.BonusStats;
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
            var stuffArmor = (Armor)stuff;

            if(stuffArmor.ArmorType <= ArmorMastery)
            {
                UnequipArmor();
                CharacterArmor = stuff;
                StuffInventory.Remove(stuff);
                ArmorAmount += stuff.ArmorOfArmor;
            }
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
        if(CharacterWeapon.GetType() == typeof(DoubleWeapon))
        {
            var ambidextrWeapon = (DoubleWeapon)CharacterWeapon;
            StuffInventory.Add(ambidextrWeapon.Weapon1);
            StuffInventory.Add(ambidextrWeapon.Weapon2);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
        else if(CharacterWeapon.GetType() == typeof(Greatsword))
        {
            CanEquipShield = true;
            StuffInventory.Add(CharacterWeapon);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
        else if (!(CharacterWeapon.GetType() == typeof(Fist)))
        {
            StuffInventory.Add(CharacterWeapon);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
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
        Coins += (soldItem.Price) / 4;
    }

    public void BuyStuff(Stuff boughtItem)
    {
        if (boughtItem.Price <= Coins)
        {
            Coins -= boughtItem.Price;
            StuffInventory.Add(boughtItem);
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

    //Getters / Setters
    public string GetTypeDisplay()
    {
        if (fightImgUrl == "img/Character/fightRogue.png")
        {
            return "Voleur";
        }
        else if (fightImgUrl == "img/Character/fightWizard.png")
        {
            return "Magicien";
        }
        else if (fightImgUrl == "img/Character/fightFighter.png")
        {
            return "Guerrier";
        }
        else if (fightImgUrl == "img/Character/fightCleric.png")
        {
            return "Clerc";
        }
        else return "Ranger";
    }
    public string GetHpDisplay()
    {
        return CurrentHitPoints + "/" + MaxHitPoints;
    }

    public string GetXpDisplay()
    {
        return CurrentXp + "/" + XpToLevel;
    }

    public string GetStatsDisplay()
    {
        return "Armure : "+ArmorAmount+" | Puissance : "+Statistics;
    }

    public void SetIsRested(Boolean isRested)
    {
        IsRested = isRested;
    }

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}