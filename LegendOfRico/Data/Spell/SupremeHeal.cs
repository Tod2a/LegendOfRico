namespace LegendOfRico.Data;

public class SupremeHeal : Spells
{
    public override string SpellName { get; protected set; } = "Soin suprême (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if (CurrentNumberOfUses > 0)
        {
            player.ReceiveHeal(player.MaxHitPoints);
            if (player.PartyMember != null)
            {
                player.PartyMember.ReceiveHeal(player.PartyMember.MaxHitPoints);
                s += player.Name + " rend tous ses points de vie au groupe ! ";
            }
            else
            {
                s += player.Name + " s'est rendu tous ses points de vie ! ";
            }

            CurrentNumberOfUses--;
            SpellName = "Soin suprême (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}