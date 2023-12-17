namespace LegendOfRico.Data;

public class Protection : Spells
{
    public override string SpellName { get; protected set; } = "Protection (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    protected override string SpellEffect(Character player, Monster target)
    {
        CurrentNumberOfUses--;
        SpellName = "Protection (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        player.SetProtectDuration(10);
        if(player.PartyMember != null) 
        { 
            player.PartyMember.SetProtectDuration(10);
            return player.Name + " lance Protection sur votre groupe ! ";
        }
        else
        {
            return player.Name + " se protège ! ";
        }
    }
}