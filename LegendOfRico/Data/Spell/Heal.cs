namespace LegendOfRico.Data;

public class Heal : Spells
{
    public override string SpellName { get; protected set; } = "Soin (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 5;
    public int MaxValue => 15;
    public double CritChance = 0.05;

    public override string UseSpell(Game currentGame)
    {
        string s = "";

        if(CurrentNumberOfUses > 0)
        {
            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)((currentGame.Player.Statistics / 50) * healRoll);

            if ((new Random()).NextDouble() <= CritChance)
            {
                s += "Coup critique !";
                healRoll *= 2;
            }
            currentGame.Player.ReceiveHeal(healRoll);
            s += "Votre groupe est soigné de " + healRoll + " points de vie!";
            CurrentNumberOfUses--;
            SpellName = "Soin (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}