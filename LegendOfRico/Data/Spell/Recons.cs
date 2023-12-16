namespace LegendOfRico.Data;

public class Recons : Spells
{
    public override string SpellName { get; protected set; } = "Reconstitution (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

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
            SpellName = "Reconstitution (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}