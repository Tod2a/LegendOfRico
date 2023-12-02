namespace LegendOfRico.Data;

public abstract class Monster
{
    public abstract string MonsterName { get; set; }
    public abstract int MonsterHP { get; set; }
    public abstract int MonsterCurrentHP { get; set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public TypeOfDamage[] MonsterResistance { get; private set; }
    public TypeOfMonster MonsterType { get; private set; }
    public Item[] LootTable { get; private set; }
    public abstract int XpGranted { get; set; }
    public abstract int MonsterMinDamage { get; set; }
    public abstract int MonsterMaxDamage { get; set; }
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

    public string Hit(Character target)
    {
        Random dice = new Random();
        int damage = dice.Next(MonsterMinDamage, MonsterMaxDamage + 1);
        double dodge = dice.NextDouble();
        if (dodge < target.ChanceToDodge)
        {
            return "Le monstre lance une attaque que vous avez esquivée";
        }
        else
        {
            target.TakeDamage(damage);
            return MonsterName + " vous inflige " + (damage - target.ArmorAmount) + " dégats";
        } 
    }
}