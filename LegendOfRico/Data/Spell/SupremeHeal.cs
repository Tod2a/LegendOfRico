namespace LegendOfRico.Data;

public class SupremeHeal : Spells
{
    public override string SpellName { get; protected set; } = "Soin suprême (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public int MinValue => 30;
    public int MaxValue => 40;
    public double CritChance = 0.25;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    protected override string SpellEffect(Character player, Monster target)
    {
        string s = "";
        CurrentNumberOfUses--;
        SpellName = "Soin suprême (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";

        int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
        healRoll += (player.Statistics / 50) * healRoll;

        if ((new Random()).NextDouble() <= CritChance)
        {
            s += "Coup critique ! ";
            healRoll *= 2;
        }
        player.ReceiveHeal(healRoll);
        if (player.PartyMember != null)
        {
            player.PartyMember.ReceiveHeal(healRoll);
            return s + player.Name + " soigne le groupe de " + healRoll + " points de vie ! ";
        }
        else
        {
            return s + player.Name + " est soigné de " + healRoll + " points de vie ! ";
        }
    }
}