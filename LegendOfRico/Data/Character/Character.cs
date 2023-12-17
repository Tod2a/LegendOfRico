using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace LegendOfRico.Data;
public abstract class Character 
{
    public string Name { get; set; }
    //Variable + propriétés de niveau qui va permettre de trigger la fonction à chaque changement de niveau
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
    //Paramètres de gestion des points de vies
    public abstract int MaxHitPoints { get; protected set; }
    public abstract int CurrentHitPoints { get; set; }
    //Paramètres nécessaire à la création des personnages à recruter à la taverne et à la gestion de groupe
    public Character PartyMember { get; set; }
    public int RecruitingPrice { get; set; }
    public bool IsMainCharacter { get; set; } = true;
    //Paramètres de gestion d'inventaire, équipements, sorts, inventaire, quêtes
    public int Coins { get; private set; } = 0;
    public abstract Stuff CharacterWeapon { get; set; }
    public abstract Stuff CharacterShield { get; set; }
    public abstract bool CanEquipShield { get; set; }
    public abstract Stuff CharacterArmor { get; set; }
    public abstract List<TypeOfWeapon> WeaponMastery { get; }
    public abstract TypeOfArmor ArmorMastery { get; }
    public abstract List<Spells> SpellBook { get; protected set; }
    public List<Consumable> ConsumableInventory { get; private set; }
    public List<Stuff> StuffInventory { get; private set; }
    public List<Quest> QuestsBook { get; set; }
    public CollectQuest CollectQuest { get; set; }
    //Paramètre de familier utilisé pour le Ranger
    public virtual Beast Pet { get; set; }
    //Paramètres utilisé pour l'affichage sur la map, en combat et en collecte
    public virtual string fightImgUrl { get; }
    public string MapSprite {  get ; set;}
    public int CollectPosI = 0;
    public int CollectPosJ = 5;
    public int PositionI { get; set; } = 250;
    public int PositionJ { get; set; } = 250;
    //Paramètres de gestion de repos et utilisés en cas de défaite au combat
    public bool IsRested { get; private set; } = true;
    public int lastRestVillageI { get; set; } = 250;
    public int LastRestVillageJ { get; set; } = 250;
    //Paramètres de gestion de statistiques utilisée pour les combats
    public abstract int Statistics { get; set; }
    public abstract int ArmorAmount { get; set; }
    public abstract double ChanceToDodge { get; protected set; }
    public bool HasFrostArmor { get; private set; } = false;
    public int FrostArmorAdditionalArmor { get; private set; } = 0;
    public bool IsProtected { get; private set; } = false;
    public int ProtectDuration { get; private set; } = 0;
    public bool IsEvading { get; private set; } = false;
    public int EvadeDuration { get; private set; } = 0;
    //Paramètres d'état pour vérifier si le personnage souffre d'afflictions
    public bool IsFrozen { get; private set; } = false;
    public bool IsPoisoned { get; set; } = false;
    public int PoisonDamage { get; set; } = 1;
    public bool IsBurning { get; set; } = false;
    public int BurnDuration { get; set; } = 0;
    //Paramètres de gestion de l'avancée sur la quêtre principale du jeu, voir si le charcater à vaincu un boss
    public bool Joydead { get; set; } = false;
    public bool Scorpiodead { get; set; } = false;
    public bool Wukongdead { get; set; } = false;
    public bool Tontatondead { get; set; } = false;



    //Constructeur sans paramètre qui initialisera les inventaires et le livre de quête avec les quêtes de base du jeu
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

    //Fonction abstract qui sera trigger à chaque montée de niveau, contenu différent pour chaque class définit au sein de celle-ci
    protected abstract void CheckLearnSpell();

    //Fonctions de gestion des afflictions
    public void Burnt()
    {
        IsBurning = true;
        BurnDuration = 3;
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

    //Fonction de repos en ville qui va rechagers les sorts, soigner les Hp et les afflictions
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

    //Gestion des combats

    //Fonction qui sert a utiliser son arme, retourne un string pour pouvoir afficher les dégats infligés au monstre
    public virtual string Hit(Monster target)
    {
        string s = "";
        //Calcul des dégats
        int weaponDamageRoll =
            new Random().Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        weaponDamageRoll += Statistics / 50 * weaponDamageRoll;
        //Vérification de coup critique
        if (new Random().NextDouble() <= CharacterWeapon.WeaponCritChance) //Si l'arme crit dégâts x2
        {
            weaponDamageRoll *= 2;
            s += "Coup critique ! ";
        }
        //Vérifie si le monstre est faible au type de l'arme
        if (target.MonsterWeakness.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll *= 2;
            s += "Efficace ! ";
        }
        //Sinon vérifie si il lui est résistant
        else if (target.MonsterResistance.Contains(CharacterWeapon.WeaponTypeOfDamage))
        {
            weaponDamageRoll /= 2;
            s += "Peu efficace ! ";
        }
        //Inflige les dégats au monstre et formate la phrase affichée sur l'interface
        target.TakeDamage(weaponDamageRoll);
        s += Name + " frappe et inflige " + weaponDamageRoll + " points de dégats ! ";
        //indique que le personage n'est plus reposé et retourne la phrase à afficher
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

    //Fonction qui va calculer la réduction de dégats si l'armure le permet et retourne un string à afficher sur l'interface
    public string TakeDamage(int damageTaken)
    {
        int actualDamageTaken = ArmorAmount > damageTaken ? 0 : damageTaken - ArmorAmount;
        CurrentHitPoints -= actualDamageTaken;
        return " et inflige " + actualDamageTaken + " points de dégats (" + damageTaken + " - " + ArmorAmount + ") à " + Name + " ! ";
    }



    //Gestion d'équipement, déséquipement
    //Fonction qui vérifie si on peut équiper un stuff et retourne un bool en fonction
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
    //Fonction d'équipement de stuff
    public void EquipStuff(Stuff stuff)
    {
        //Si veut équiper une arme
        if (stuff.TypeOfStuff == TypeOfStuff.Weapon)
        {
            var stuffWeapon = (Weapon)stuff;
            StuffInventory.Remove(stuff);
            //Si c'est un rogue avec une arme
            if (this.GetType() == typeof(Rogue) && CharacterWeapon.GetType() != typeof(Fist)) 
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
            //Si l'arme que l'on équipe est une arme a deux main, on ne peut plus porter de bouclier
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
        //Si c'est un bouclier
        else if (stuff.TypeOfStuff == TypeOfStuff.Shield)
        {
            UnequipShield();
            CharacterShield = stuff;
            StuffInventory.Remove(stuff);
            ArmorAmount += stuff.ShieldBonusArmor;
        }
        //Si c'est une armure
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

    //Fonction qui retire le bouclier
    public void UnequipShield()
    {
        if (!(CharacterShield.GetType() == typeof(FistShield)))
        {
            StuffInventory.Add(CharacterShield);
            ArmorAmount -= CharacterShield.ShieldBonusArmor;
            CharacterShield = new FistShield("Poing", "un poing", 0, 0);
        }
    }

    //Fonction qui retire l'arme
    public void UnequipWeapon()
    {
        //Si c'est une arme double
        if (CharacterWeapon.GetType() == typeof(DoubleWeapon))
        {
            var ambidextrWeapon = (DoubleWeapon)CharacterWeapon;
            StuffInventory.Add(ambidextrWeapon.Weapon1);
            StuffInventory.Add(ambidextrWeapon.Weapon2);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
        //Si c'est une épée à deux mains
        else if (CharacterWeapon.GetType() == typeof(Greatsword))
        {
            CanEquipShield = true;
            StuffInventory.Add(CharacterWeapon);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
        //Si ce n'est pas une main nue
        else if (!(CharacterWeapon.GetType() == typeof(Fist)))
        {
            StuffInventory.Add(CharacterWeapon);
            Statistics -= CharacterWeapon.BonusStats;
            CharacterWeapon = new Fist("Poing", "un poing", 0, 1, 3, 0);
        }
    }

    //Déséquipement de l'armure, on se retrouve torse nu
    public void UnequipArmor()
    {
        if (!(CharacterArmor.GetType() == typeof(Topless)))
        {
            StuffInventory.Add(CharacterArmor);
            ArmorAmount -= CharacterArmor.ArmorOfArmor;
            CharacterArmor = new Topless("Rien", "Bah rien", 0, TypeOfArmor.None, 0); ;
        }
    }
    

    //Gestion des loots et d'achats/vente au marchand
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
        else
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


}