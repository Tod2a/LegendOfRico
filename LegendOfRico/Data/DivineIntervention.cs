namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName => "Divine Intervention";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override int MinValue => 60;
    public override int MaxValue => 80;
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
        target.ReceiveHeal((new Random()).Next(MinValue, MaxValue + 1));
    }
}