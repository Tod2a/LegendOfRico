
using static System.Net.Mime.MediaTypeNames;

namespace LegendOfRico.Data;

public abstract class Monster
{
    //Création d'un dés pour les calculs random
    Random dice = new Random();
    public abstract string MonsterName { get; set; }
    //Paramètres de points de vies
    public abstract int MonsterHP { get; set; }
    public abstract int MonsterCurrentHP { get; set; }
    //Paramètres utilisés pendant les combats, résistance, faiblesses, listes des attaques, ...
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public abstract TypeOfDamage[] MonsterResistance { get; }
    public MonsterHit? MonsterHit { get; set; }
    public abstract MonsterHit[] HitTable { get; set; }
    public virtual List<Stuff> LootTable { get; protected set; } = new List<Stuff>();
    public abstract int XpGranted { get; set; }
    public bool IsBurning { get; private set; }
    public int BurnDuration { get; private set; }
    public bool IsFrozen { get; private set; }
    public bool IsCold { get; set; } = false;
    public abstract string fightImgUrl { get; set; }
    //Paramètres qui servent à définir le type et la race du monstre, utilisés pour les quêtes et certaines interactions
    public abstract TypeOfMonster MonsterType { get; set; }
    public abstract TypeOfBreed MonsterBreed { get; set; }

    
    //Fonctions servants au combats, pour les dégats et les afflictions
    public void TakeDamage(int damageReceived)
    {
        MonsterCurrentHP -= damageReceived;
    }

    public void ReceiveHeal(int healAmount)
    {
        if (MonsterCurrentHP + healAmount > MonsterHP)
        {
            MonsterCurrentHP = MonsterHP;
        }
        else
        {
            MonsterCurrentHP += healAmount;
        }
    }

    public void Burnt()
    {
        IsBurning = true;
        if(BurnDuration < 3)
        {
            BurnDuration = 3;
        }
    }
    
    public void Incinerate()
    {
        IsBurning = true;
        BurnDuration = 10;
    }

    public int BurnTic()
    {
        int ticDmg = (MonsterHP / 10);
        MonsterCurrentHP -= ticDmg;
        BurnDuration--;
        if(BurnDuration <= 0)
        {
            IsBurning = false;
        }
        return ticDmg;
    }

    public void Frozen()
    {
        if(IsFrozen == true)
        {
            IsFrozen = false;
        }
        else
        {
            IsFrozen = true;
        }
    }

    public void SetIsCold(bool isCold)
    {
        IsCold = isCold;
    }

    //Sélection d'un loot
    public Stuff DropItem()
    {
        return LootTable[dice.Next(0, LootTable.Count)];
    }

    //Gestion du combat

    //Fonction qui va Selectionner une attaque parmis la HitTable
    public void SelectHit()
    {
        MonsterHit hit = HitTable[dice.Next(HitTable.Length)];
        MonsterHit = hit;
    }

    //Fonction d'attaque du monstre qui prend une target en paramètre et retourne un texte à afficher sur l'interface de combat
    public string Hit(Character target)
    {
        string s = "";
        //Calcul des dégats en se servant du dés
        int damage = dice.Next(MonsterHit.MinDamage, MonsterHit.MaxDamage + 1);
        //si le monstre est une bête on recalcul les dégats de la bête car possibilité d'appaisement
        damage = CheckBeast(damage);
        //Cas ou le personnage est protégé par un sort
        damage = TargetProtected(target, damage);
        //Calcul de l'esquive avec le dés et les chances de dodge
        double dodge = dice.NextDouble();
        if (target.IsEvading)
        {
            s += "Le monstre attaque " + target.Name + " mais "+target.Name+" se confond dans les ombres !";
            target.SetEvadeDuration(-1);
        }
        else if (dodge < target.ChanceToDodge)
        {
            s += "Le monstre attaque " + target.Name + " mais c'est esquivé !";
        }
        //une fois tout ceci vérifié, le monstre attaque
        else
        {
            //Foramtage du texte pour l'inteface de combat
            s += MonsterName + " lance " + MonsterHit.Name + target.TakeDamage(damage);
            //vérification des chances de bruler de l'attaque
            s += MonsterBurn(target);
            //Vérification des chances d'empoisonnement de l'attaque
            s += MonsterPoison(target);
        }
        return s;
    }

    //Fonction d'attaque sur tout le groupe
    public string DoubleHit (Character target1, Character target2)
    {
        string s = "";
        //Calcul des dégats
        int damage1 = dice.Next(MonsterHit.MinDamage, MonsterHit.MaxDamage + 1);
        //Check si le monstre est une bête
        damage1 = CheckBeast(damage1);
        //Duplication des dégats
        int damage2 = damage1;
        // vérification des protection de chacun des personnages
        damage1 = TargetProtected(target1, damage1);
        damage2 = TargetProtected(target2, damage2);
        //début de la création du texte
        s += MonsterName + " lance " + MonsterHit.Name + " qui est une attaque de zone ";
        //Gestion de l'attaque sur le premier personage
        double dodge = dice.NextDouble();
        if (dodge < target1.ChanceToDodge)
        {
            s += target1.Name + " esquive et ";
        }
        else
        {
            s += target1.TakeDamage(damage1);
            s += MonsterBurn(target1);
            s += MonsterPoison(target1);
        }
        //Gestion de l'attaque sur le deuxieme personnage
        dodge = dice.NextDouble();
        if (dodge < target2.ChanceToDodge)
        {
            s += target2.Name + " esquive";
        }
        else
        {
            s += target2.TakeDamage(damage2);
            s += MonsterBurn(target2);
            s += MonsterPoison(target2);  
        }
        return s;
    }

    //Fonction privée qui vérifie si l'attaque brule et retourne un texte à mettre dans le message de combat
    private string MonsterBurn(Character target)
    {
        if (MonsterHit.chanceToBurn > 0)
        {
            double Test = dice.NextDouble();
            if (Test < MonsterHit.chanceToBurn)
            {
                target.Burnt();
                return " et l'attaque brûle ";
            }
        }
        return "";
    }

    //Fonction privée qui vérifie si l'attaque empoisonne et retourne un texte à mettre dans le message de combat
    private string MonsterPoison(Character target)
    {
        if (MonsterHit.chanceToPoisoned > 0)
        {
            double test = dice.NextDouble();
            if (test < MonsterHit.chanceToPoisoned)
            {
                target.Poisoned();
                return " et l'attaque empoisonne ";

            }
        }
        return "";
    }

    //Fonction privée qui vérifie la protection de la target et retoure un int qui sont les dégats après vérification
    private int TargetProtected (Character target, int damage)
    {
        int idamage = damage;
        if (target.IsProtected)
        {
            idamage = (idamage * 2) / 3;
            target.SetProtectDuration(-1);
        }
        return idamage;
    }

    //Fonction privée qui vérifie si le monstre est une bête et retourne les dégats après vérification
    private int CheckBeast (int damage)
    {
        int idamage = damage;
        if (this.MonsterType == TypeOfMonster.Beast)
        {
            //Deux boss qui sont eux aussi des bête (le singe et le scorpion)
            if (this.GetType() == typeof(EternalScorpio) || this.GetType() == typeof(Sunwukong))
            {
                var soothedBeast = (Boss)this;
                idamage = soothedBeast.DamageSoothed(idamage);
            }
            else
            {
                var soothedBeast = (Beast)this;
                idamage = soothedBeast.DamageSoothed(idamage);
            }
        }
        return idamage;
    }

}