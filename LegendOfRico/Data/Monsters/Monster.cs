
namespace LegendOfRico.Data;

public abstract class Monster
{
    Random dice = new Random();
    public abstract string MonsterName { get; set; }
    public abstract int MonsterHP { get; set; }
    public abstract int MonsterCurrentHP { get; set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public TypeOfDamage[] MonsterResistance { get; private set; } = new TypeOfDamage[] { };
    public abstract TypeOfMonster MonsterType { get; set; }
    //ajout d'une race à chaque monstre pour faciliter la création de quête par après, on pourra faire des quetes qui cibles des bêtes ou des spiders
    public abstract TypeOfBreed MonsterBreed { get; set; }
    public virtual List<Stuff> LootTable { get; protected set; } = new List<Stuff>();
    public abstract int XpGranted { get; set; }
    public MonsterHit MonsterHit { get; set; }
    public abstract MonsterHit[] HitTable { get; set; }
    public Boolean IsBurning { get; private set; }
    public int BurnDuration { get; private set; }
    public Boolean IsFrozen { get; private set;}
    public abstract string fightImgUrl {  get; set; }
    
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
    private string SelectHit()
    {
        MonsterHit hit = HitTable[dice.Next(HitTable.Length)];

                
        MonsterHit = hit;

        return hit.Name;
    }

    public string Hit(Character target)
    {
        string s = "";
        string hitname = SelectHit();
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
        if (dodge < target.ChanceToDodge)
        {
            s += "Le monstre attaque mais vous esquivez !";
        }
        else
        {
            s += MonsterName +" lance " + hitname + target.TakeDamage(damage);
        }
        return s;
    }

    public Stuff DropItem()
    {
        return LootTable[new Random().Next(0, LootTable.Count)];
    }
}