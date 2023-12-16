namespace LegendOfRico.Data;

public class GreaterHeal : Spells
{
    public override string SpellName { get; protected set; } = "Soin supérieur (10/10)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 15;
    public int MaxValue => 20;
    public double CritChance = 0.15;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if (CurrentNumberOfUses > 0)
        {
            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (player.Statistics / 50) * healRoll;

            if ((new Random()).NextDouble() <= CritChance)
            {
                s += "Coup critique !";
                healRoll *= 2;
            }
            player.ReceiveHeal(healRoll);
            if (player.PartyMember != null)
            {
                player.PartyMember.ReceiveHeal(healRoll);
                s += player.Name + " soigne le groupe de " + healRoll + " points de vie ! ";
            }
            else
            {
                s += player.Name + " est soigné de " + healRoll + " points de vie ! ";
            }

            CurrentNumberOfUses--;
            SpellName = "Soin supérieur (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}