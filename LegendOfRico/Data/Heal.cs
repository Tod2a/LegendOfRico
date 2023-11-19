namespace LegendOfRico.Data;

public class Heal : Spells
{
    public override string SpellName => "Heal";
    public override int MaxNumberOfUses => 15;
    public override int MinValue => 5;
    public override int MaxValue => 15;
    public double CritChance = 0.05;

    public void UseSpell(Character target)
    {
        int HealRoll = (new Random()).Next(MinValue, MaxValue + 1);
        if ((new Random()).NextDouble() <= CritChance)
        {
            HealRoll *= 2;
        }
        target.ReceiveHeal(HealRoll);
    }
}