namespace LegendOfRico.Data;

public class Pyroblast : Spells
{
    public override string SpellName => "Pyroblast";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override int MinValue => 70;
    public override int MaxValue => 100;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.1;
    public double BurnChance = 0.5;

    public void UseSpell(Monster target)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        target.TakeDamage(damageRoll);
        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= BurnChance && !target.MonsterResistance.Contains(SpellType))
        {
            target.Burnt();
        }
        target.TakeDamage(damageRoll);
    }
}