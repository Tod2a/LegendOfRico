namespace LegendOfRico.Data;

public abstract class Monster
{
    public string MonsterName { get; private set; }
    public int MonsterHP { get; private set; }
    public TypeOfDamage[] MonsterWeakness { get; private set; }
    public TypeOfDamage[] MonsterResistance { get; private set; }
    public TypeOfMonster MonsterType { get; private set; }
    public Item[] LootTable { get; private set; }
    public int XpGranted { get; private set; }
    public int MonsterMinDamage { get; private set; }
    public int MonsterMaxDamage { get; private set; }
    public Boolean IsBurning { get; private set; }
    
    public void TakeDamage(int DamageReceived)
    {
        MonsterHP -= DamageReceived;
    }
    
    public void Burnt()
    {
        IsBurning = true;
    }
}