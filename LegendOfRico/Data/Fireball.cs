namespace LegendOfRico.Data;

public class Fireball : Spells
{
    public override string SpellName => "Fireball";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override int MinValue => 10;
    public override int MaxValue => 30;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.05;
    public double BurnChance = 0.2;

    public override void UseSpell(Monster target)
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

    public override void UseSpell(Character target)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        target.TakeDamage(damageRoll);
        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= BurnChance)
        {
            target.Burnt();
        }
        target.TakeDamage(damageRoll);
    }
}