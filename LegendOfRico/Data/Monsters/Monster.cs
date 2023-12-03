
namespace LegendOfRico.Data;

public abstract class Monster
{
    Random dice = new Random();
    public abstract string MonsterName { get; set; }
    public abstract int MonsterHP { get; set; }
    public abstract int MonsterCurrentHP { get; set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public TypeOfDamage[] MonsterResistance { get; private set; }
    public TypeOfMonster MonsterType { get; private set; }
    public Item[] LootTable { get; private set; }
    public abstract int XpGranted { get; set; }
    public int MonsterMinDamage { get; set; }
    public int MonsterMaxDamage { get; set; }
    public abstract MonsterHit[] HitTable { get; set; }
    public Boolean IsBurning { get; private set; }
    public Boolean IsFrozen { get; private set;}
    public abstract string fightImgUrl {  get; set; }
    
    public void TakeDamage(int damageReceived)
    {
        MonsterCurrentHP -= damageReceived;
    }
    
    public void Burnt()
    {
        IsBurning = true;
    }

    public void Frozen()
    {
        IsFrozen = true;
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
        double dodge = dice.NextDouble();
        if (dodge < target.ChanceToDodge)
        {
            return "Le monstre lance une attaque que vous avez esquivée";
        }
        else
        {
            return MonsterName +" lance " + hitname + target.TakeDamage(damage);
        } 
    }
}