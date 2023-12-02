namespace LegendOfRico.Data;

public abstract class Monster
{
    public string MonsterName { get; set; }
    public int MonsterHP { get; set; }
    public int MonsterCurrentHP { get; set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public TypeOfDamage[] MonsterResistance { get; private set; }
    public TypeOfMonster MonsterType { get; private set; }
    public Item[] LootTable { get; private set; }
    public int XpGranted { get; private set; }
    public int MonsterMinDamage { get; private set; }
    public int MonsterMaxDamage { get; private set; }
    public Boolean IsBurning { get; private set; }
    public Boolean IsFrozen { get; private set;}
    public string fightImgUrl {  get; set; }
    
    public void TakeDamage(int damageReceived)
    {
        MonsterHP -= damageReceived;
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
}