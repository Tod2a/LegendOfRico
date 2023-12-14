
using static System.Net.Mime.MediaTypeNames;

namespace LegendOfRico.Data;

public abstract class Monster
{
    Random dice = new Random();
    public abstract string MonsterName { get; set; }
    public abstract int MonsterHP { get; set; }
    public abstract int MonsterCurrentHP { get; set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public abstract TypeOfDamage[] MonsterResistance { get; }
    public abstract TypeOfMonster MonsterType { get; set; }
    //ajout d'une race à chaque monstre pour faciliter la création de quête par après, on pourra faire des quetes qui cibles des bêtes ou des spiders
    public abstract TypeOfBreed MonsterBreed { get; set; }
    public virtual List<Stuff> LootTable { get; protected set; } = new List<Stuff>();
    public abstract int XpGranted { get; set; }
    public MonsterHit MonsterHit { get; set; } = new MonsterHit();
    public abstract MonsterHit[] HitTable { get; set; }
    public Boolean IsBurning { get; private set; }
    public int BurnDuration { get; private set; }
    public Boolean IsFrozen { get; private set;}
    public abstract string fightImgUrl {  get; set; }
    public bool IsCold { get; set; } = false;
    
    public void TakeDamage(int damageReceived)
    {
        MonsterCurrentHP -= damageReceived;
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
    public void SelectHit()
    {
        MonsterHit hit = HitTable[dice.Next(HitTable.Length)];

                
        MonsterHit = hit;

    }

    public string Hit(Character target)
    {
        string s = "";
        string hitname = MonsterHit.Name;
        bool burnt = false;
        int damage = dice.Next(MonsterHit.MinDamage, MonsterHit.MaxDamage + 1);
        if(this.MonsterType == TypeOfMonster.Beast)
        {
            if(this.GetType() == typeof(EternalScorpio) || this.GetType() == typeof(Sunwukong))
            {
                var soothedBeast = (Boss)this;
                damage = soothedBeast.DamageSoothed(damage);
            }
            else
            {
                var soothedBeast = (Beast)this;
                damage = soothedBeast.DamageSoothed(damage);
            }
        }
        if (target.IsProtected)
        {
            damage = (damage*2)/3;
            target.SetProtectDuration(-1);
        }

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
        else
        {
            if (MonsterHit.chanceToBurn > 0)
            {
                double Test = dice.NextDouble();
                if (Test < MonsterHit.chanceToBurn)
                {
                    target.IsBurning = true;
                    target.BurnDuration = 3;
                    burnt = true;
                }
            }
            s += MonsterName +" lance " + hitname + target.TakeDamage(damage);
            if(burnt)
            {
                s += " et l'attaque vous brûle ";
            }
        }
        return s;
    }

    public string DoubleHit (Character target1, Character target2)
    {
        string s = "";
        string hitname = MonsterHit.Name;
        bool burnt1 = false;
        bool burnt2 = false;
        int damage1 = dice.Next(MonsterHit.MinDamage, MonsterHit.MaxDamage + 1);
        if (this.MonsterType == TypeOfMonster.Beast)
        {
            if (this.GetType() == typeof(EternalScorpio) || this.GetType() == typeof(Sunwukong))
            {
                var soothedBeast = (Boss)this;
                damage1 = soothedBeast.DamageSoothed(damage1);
            }
            else
            {
                var soothedBeast = (Beast)this;
                damage1 = soothedBeast.DamageSoothed(damage1);
            }
        }
        int damage2 = damage1;
        if (target1.IsProtected)
        {
            damage1 = (damage1 * 2) / 3;
            target1.SetProtectDuration(-1);
        }
        if (target2.IsProtected)
        {
            damage2 = (damage2 * 2) / 3;
            target2.SetProtectDuration(-1);
        }
        s += MonsterName + " lance " + hitname + " qui est une attaque de zone ";
        double dodge = dice.NextDouble();
        if (dodge < target1.ChanceToDodge)
        {
            s += target1.Name + " esquive et ";
        }
        else
        {
            if (MonsterHit.chanceToBurn > 0)
            {
                double Test = dice.NextDouble();
                if (Test < MonsterHit.chanceToBurn)
                {
                    target1.IsBurning = true;
                    target1.BurnDuration = 3;
                    burnt1 = true;
                }
            }
            s += target1.TakeDamage(damage1);
            if (burnt1)
            {
                s += " et  " + target1.Name + " est brulé ";
            }
        }
        dodge = dice.NextDouble();
        if (dodge < target2.ChanceToDodge)
        {
            s += target2.Name + " esquive";
        }
        else
        {
            if (MonsterHit.chanceToBurn > 0)
            {
                double Test = dice.NextDouble();
                if (Test < MonsterHit.chanceToBurn)
                {
                    target2.IsBurning = true;
                    target2.BurnDuration = 3;
                    burnt2 = true;
                }
            }
            s += target2.TakeDamage(damage2);
            if (burnt2)
            {
                s += " et  " + target2.Name + " est brulé ";
            }
        }
        return s;
    }

    public Stuff DropItem()
    {
        return LootTable[new Random().Next(0, LootTable.Count)];
    }

    public void SetIsCold(bool isCold)
    {
        IsCold = isCold;
    }
}