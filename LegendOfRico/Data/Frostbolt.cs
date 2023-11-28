namespace LegendOfRico.Data;

public class Frostbolt : Spells
{
    public override string SpellName => "Frostbolt";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override int MinValue => 15;
    public override int MaxValue => 25;
    public TypeOfDamage SpellType = TypeOfDamage.Cold;
    public double CritChance = 0.2;
    public double FreezeChance = 0.05;

    public void UseSpell(Monster target)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        target.TakeDamage(damageRoll);
        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= FreezeChance && !target.MonsterResistance.Contains(SpellType))
        {
            target.Frozen();
        }
        target.TakeDamage(damageRoll);
    }
}