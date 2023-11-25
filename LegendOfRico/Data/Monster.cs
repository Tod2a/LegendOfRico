namespace LegendOfRico.Data;

public abstract class Monster
{
    public string MonsterName { get; private set; }
    public int MonsterHP { get; private set; }
    public abstract TypeOfDamage[] MonsterWeakness { get; }
    public TypeOfDamage[] MonsterResistance { get; private set; }
    public TypeOfMonster MonsterType { get; private set; }
    public Item[] LootTable { get; private set; }
    public int XpGranted { get; private set; }
    public int Coins {get;}
    public int MonsterMinDamage { get; private set; }
    public int MonsterMaxDamage { get; private set; }
    public Boolean IsBurning { get; private set; }
    public Boolean IsFrozen { get; private set;}
    
    public void TakeDamage(int DamageReceived)
    {
        MonsterHP -= DamageReceived;
    }
    
    public void Burnt()
    {
        IsBurning = true;
    }

    public void Frozen()
    {
        IsFrozen = true;
    }
}