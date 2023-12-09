namespace LegendOfRico.Data;

public class Heal : Spells
{
    public override string SpellName { get; protected set; } = "Soin (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 5;
    public int MaxValue => 7;
    public double CritChance = 0.05;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if(CurrentNumberOfUses > 0)
        {
            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)((player.Statistics / 50) * healRoll);

            if ((new Random()).NextDouble() <= CritChance)
            {
                s += "Coup critique !";
                healRoll *= 2;
            }
            player.ReceiveHeal(healRoll);
            if(player.PartyMember != null)
            {
                player.PartyMember.ReceiveHeal(healRoll);
                s += player.Name + " soigne le groupe de " + healRoll + " points de vie ! ";
            }
            else
            {
                s += player.Name + " est soigné de " + healRoll + " points de vie ! ";
            }
            
            CurrentNumberOfUses--;
            SpellName = "Soin (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}