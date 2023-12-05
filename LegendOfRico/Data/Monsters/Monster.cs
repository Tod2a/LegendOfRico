
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
    public Item[] LootTable { get; private set; }
    public abstract int XpGranted { get; set; }
    public int MonsterMinDamage { get; set; }
    public int MonsterMaxDamage { get; set; }
    public abstract MonsterHit[] HitTable { get; set; }
    public Boolean IsBurning { get; private set; }
    public int BurnDuration { get; private set; }
    public Boolean IsFrozen { get; private set;}
    public abstract string fightImgUrl {  get; set; }
    public virtual string PetImgUrl { get; set; } = " ";
    
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

        // Vérifie si MinDamage est inférieur à MaxDamage
        if (hit.MinDamage > hit.MaxDamage)
        {
            // Inverse les valeurs si nécessaire
            int temp = hit.MinDamage;
            hit.MinDamage = hit.MaxDamage;
            hit.MaxDamage = temp;
        }

        MonsterMinDamage = hit.MinDamage;
        MonsterMaxDamage = hit.MaxDamage;

        return hit.Name;
    }

    public string Hit(Character target)
    {
        string hitname = SelectHit();
        Console.WriteLine(MonsterMinDamage);
        Console.WriteLine(MonsterMaxDamage);
        int damage = dice.Next(MonsterMinDamage, MonsterMaxDamage + 1);
        if(this.MonsterType == TypeOfMonster.Beast)
        {
            var soothedBeast = (Beast)this;
            damage = soothedBeast.DamageSoothed(damage);
        }
        double dodge = dice.NextDouble();
        if (dodge < target.ChanceToDodge)
        {
            return "Le monstre attaque mais vous esquivez !";
        }
        else
        {
            return MonsterName +" lance " + hitname + target.TakeDamage(damage);
        } 
    }
}