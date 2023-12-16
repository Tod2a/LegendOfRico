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
    public Character PartyMember { get; set; }
    public Boolean IsMainCharacter { get; set; } = true;
    public abstract double ChanceToDodge { get; protected set; }
    public abstract Stuff CharacterWeapon { get; set; }
    public abstract Stuff CharacterShield { get; set; }
    public abstract Stuff CharacterArmor { get; set; }
    public abstract List<Spells> SpellBook { get; protected set; }
    public List<Consumable> ConsumableInventory { get; private set; }
    public List<Stuff> StuffInventory { get; private set; }
    public List<Quest> QuestsBook { get; set; }
    public CollectQuest CollectQuest { get; set; }
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
    public Boolean HasFrostArmor { get; private set; } = false;
    public int FrostArmorAdditionalArmor { get; private set; } = 0;
    public Boolean IsFrozen { get; private set; } = false;
    public bool IsPoisoned { get; set; } = false;
    public int PoisonDamage { get; set; } = 1;
    public Boolean IsBurning { get; set; } = false;
    public int BurnDuration { get; set; } = 0;
    public Boolean IsProtected { get; private set; } = false;
    public int ProtectDuration { get; private set; } = 0;
    public bool IsEvading { get; private set; } = false;
    public int EvadeDuration { get; private set; } = 0;
    public bool Joydead { get; set; } = false;
    public bool Scorpiodead { get; set; } = false;
    public bool Wukongdead { get; set; } = false;
    public bool Tontatondead { get; set; } = false;
    public int CollectPosI = 0;
    public int CollectPosJ = 5;
    private int positionI = 250;


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
            new Potion("Petite potion de soin","Cette potion vous soignera entre 1 et 10 points de vie en combat ou hors combat", 5, 1, 10, 5),
            new Potion("Potion de soin","Cette potion vous soignera entre 10 et 20 points de vie en combat ou hors combat", 10, 10, 20, 0),
            new Potion("Grande potion de soin","Cette potion vous soignera entre 20 et 40 points de vie en combat ou hors combat", 20, 20, 40, 0),
            new Potion("Enorme potion de soin","Cette potion vous soignera entre 40 et 80 points de vie en combat ou hors combat", 40, 40, 80, 0),
            new BurnHeal("Anti-brulure","Un objet raffraichissant qui vous soulagera de la brulure la plus sévère", 10),
            new PoisonedHeal("Antidote", "Un anti-poison qui vous soigne de l'empoisonnement", 5),
            new SmokedBall("Boule fumée","Cela pourrait s'avérer utile si le combat devient trop dangereux", 50),
            new MagicWhistle("Sifflet Magique","Ce sifflet appelera un griffon majesteux ou que vous soyez pour vous ramener en lieux sur, mais il ne fonctionne pas en combat", 50),
            new WoodFire("Feu de bois", "Ce feu de bois offre une occasion de se reposer seul ou à deux et de retrouver des forces pour l'aventure", 50)
        };
        StuffInventory = new List<Stuff> { };
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

    public void UnBurn()
    {
        IsBurning = false;
        BurnDuration = 0;
    }

    public void Poisoned()
    {
        IsPoisoned = true;
    }

    public void UnPoisoned()
    {
        IsPoisoned = false;
        PoisonDamage = 1;
    }

    public void Frozen()
    {
        IsFrozen = true;
    }

    public void Unfreeze()
    {
        IsFrozen = false;
    }

    public void HealAffliction ()
    {
        UnBurn();
        Unfreeze();
        UnPoisoned();
    }

    public void Rest()
    {
        CurrentHitPoints = MaxHitPoints;
        ProtectDuration = 0;
        IsProtected = false;
        foreach (var spell in SpellBook)
        {
            spell.RefreshSpell();
        }
        HealAffliction();
        if (HasFrostArmor)
        {
            HasFrostArmor = false;
            ArmorAmount -= FrostArmorAdditionalArmor;
            FrostArmorAdditionalArmor = 0;
        }
    }

    public virtual string Hit(Monster target)
    {
        string s = "";
        int weaponDamageRoll =
            new Random().Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        weaponDamageRoll += Statistics / 10 * weaponDamageRoll;

        if (new Random().NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            weaponDamageRoll *= 2;
            s += "Coup critique ! ";
        }

        if (target.MonsterWeakness.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll *= 2;
            s += "Efficace ! ";
        }
        else if (target.MonsterResistance.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll /= 2;
            s += "Peu efficace ! ";
        }

        target.TakeDamage(weaponDamageRoll);
        s += Name + " frappe et inflige " + weaponDamageRoll + " points de dégats ! ";

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
        return " et inflige " + actualDamageTaken + " points de dégats (" + damageTaken + " - " + ArmorAmount + ") à " + Name + " ! ";
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
        if (stuff.TypeOfStuff == TypeOfStuff.Weapon) //Si veut équiper une arme
        {
            var stuffWeapon = (Weapon)stuff;
            StuffInventory.Remove(stuff);
            if (this.GetType() == typeof(Rogue) && CharacterWeapon.GetType() != typeof(Fist)) //Si c'est un rogue avec une arme
            {
                if (CharacterWeapon.GetType() != typeof(DoubleWeapon)) //Si pas de main gauche
                {
                    Statistics -= CharacterWeapon.BonusStats;
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
                    Statistics -= CharacterWeapon.BonusStats;
                    CharacterWeapon = new DoubleWeapon(weapon1.ItemName + "/" + stuff.ItemName,
                        weapon1.Description + "/" + stuff.Description,
                        weapon1.Price + stuff.Price,
                        weapon1.MinimumWeaponDamage + (stuff.MinimumWeaponDamage / 2),
                        weapon1.MaximumWeaponDamage + (stuff.MaximumWeaponDamage / 2),
                        weapon1.BonusStats + stuff.BonusStats,
                        weapon1, stuff);
                }
            }
            else if (stuffWeapon.GetType() == typeof(Greatsword))
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

            if (stuffArmor.ArmorType <= ArmorMastery)
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
        if (!(CharacterShield.GetType() == typeof(FistShield)))
        {
            StuffInventory.Add(CharacterShield);
            ArmorAmount -= CharacterShield.ShieldBonusArmor;
            CharacterShield = new FistShield("Poing", "un poing", 0, 0);
        }
    }

    public void UnequipWeapon()
    {
        if (CharacterWeapon.GetType() == typeof(DoubleWeapon))
        {
            var ambidextrWeapon = (DoubleWeapon)CharacterWeapon;
            StuffInventory.Add(ambidextrWeapon.Weapon1);
            StuffInventory.Add(ambidextrWeapon.Weapon2);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
        else if (CharacterWeapon.GetType() == typeof(Greatsword))
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
        consumable.Quantity--;
        Coins += (int)(consumable.Price) / 4;
    }

    public void BuyConsumable(Consumable boughtConsumable)
    {
        if (boughtConsumable.Price <= Coins)
        {
            Coins -= boughtConsumable.Price;
            boughtConsumable.Quantity++;
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
        return "Armure : " + ArmorAmount + " | Puissance : " + Statistics;
    }

    public void SetIsRested(Boolean isRested)
    {
        IsRested = isRested;
    }

    public void SetCoins(int coins)
    {
        Coins += coins;
    }

    public void SetCollectQuest()
    {
        foreach(var quest in QuestsBook)
        {
            if(quest.GetType() == typeof(CollectQuest)) 
            {
                CollectQuest cquest = (CollectQuest)quest;
                if (PositionI == cquest.PositionI && PositionJ == cquest.PositionJ)
                {
                    CollectQuest = cquest;
                }
            }
        }
    }

    public void SetProtectDuration(int duration)
    {
        ProtectDuration += duration;
        if(ProtectDuration <= 0)
        {
            IsProtected = false;
            ProtectDuration = 0;
        }
        else if(!IsProtected && ProtectDuration > 0)
        {
            IsProtected = true;
            if(ProtectDuration > 10)
            {
                ProtectDuration = 10;
            }
        }
    }

    public void SetEvadeDuration(int duration)
    {
        EvadeDuration += duration;
        if (EvadeDuration <= 0)
        {
            IsEvading = false;
            EvadeDuration = 0;
        }
        else if (!IsEvading && EvadeDuration > 0)
        {
            IsEvading = true;
            if (EvadeDuration > 5)
            {
                EvadeDuration = 5;
            }
        }
    }

    public void SetHasFrostArmor(int additionalArmor)
    {
        ArmorAmount -= FrostArmorAdditionalArmor;
        FrostArmorAdditionalArmor = 0;

        HasFrostArmor = true;
        FrostArmorAdditionalArmor += additionalArmor;
        ArmorAmount += FrostArmorAdditionalArmor;
    }

    //gestion du changement des propriété lorsqu'on se déplace sur la carte, permet de réactualiser la carte lors d'un mouvement
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}