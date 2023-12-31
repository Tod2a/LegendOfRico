namespace LegendOfRico.Data;

public class Heal : Spells
{
    public override string SpellName { get; protected set; } = "Soin (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 5;
    public int MaxValue => 7;
    public double CritChance = 0.05;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    protected override string SpellEffect(Character player, Monster target)
    {
        string s = "";

        int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
        healRoll += (int)((player.Statistics / 50) * healRoll);
        CurrentNumberOfUses--;
        SpellName = "Soin (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        if ((new Random()).NextDouble() <= CritChance)
        {
            s += "Coup critique ! ";
            healRoll *= 2;
        }
        player.ReceiveHeal(healRoll);
        if(player.PartyMember != null)
        {
            player.PartyMember.ReceiveHeal(healRoll);
            return s + player.Name + " soigne le groupe de " + healRoll + " points de vie ! ";
        }
        else
        {
            return s + player.Name + " est soign� de " + healRoll + " points de vie ! ";
        }
            
    }
}