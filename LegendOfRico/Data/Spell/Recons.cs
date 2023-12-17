namespace LegendOfRico.Data;

public class Recons : Spells
{
    public override string SpellName { get; protected set; } = "Reconstitution (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    protected override string SpellEffect(Character player, Monster target)
    {
        CurrentNumberOfUses--;
        SpellName = "Reconstitution (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";

        player.ReceiveHeal(player.MaxHitPoints);
        if (player.PartyMember != null)
        {
            player.PartyMember.ReceiveHeal(player.PartyMember.MaxHitPoints);
            return player.Name + " rend tous ses points de vie au groupe ! ";
        }
        else
        {
            return player.Name + " s'est rendu tous ses points de vie ! ";
        }
    }
}