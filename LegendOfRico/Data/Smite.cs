namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName => "Smite";
    public override int MaxNumberOfUses => 10;
    public override int MinValue => 10;
    public override int MaxValue => 20;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public void UseSpell(Monster target)
    {
        int DamageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        target.TakeDamage(DamageRoll);
        if (target.MonsterType == TypeOfMonster.Undead)
        {
            target.Burnt();
        }
    }
}