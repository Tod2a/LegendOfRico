namespace LegendOfRico.Data;

public class Heal : Spells
{
    public override string SpellName => "Heal";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 5;
    public int MaxValue => 15;
    public double CritChance = 0.05;

    public override void UseSpell(Game currentGame)
    {
        int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
        healRoll += (int)((currentGame.Player.Statistics / 50) * healRoll);
        if ((new Random()).NextDouble() <= CritChance)
        {
            healRoll *= 2;
        }
        currentGame.Player.ReceiveHeal(healRoll);
    }
}