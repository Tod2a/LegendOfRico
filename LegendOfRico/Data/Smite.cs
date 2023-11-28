namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName => "Smite";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override int MinValue => 10;
    public override int MaxValue => 20;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override void UseSpell(Monster target)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        target.TakeDamage(damageRoll);
        if (target.MonsterType == TypeOfMonster.Undead)
        {
            target.Burnt();
        }
    }

    public override void UseSpell(Character target)
    {
        target.TakeDamage((new Random()).Next(MinValue, MaxValue + 1));
    }
}