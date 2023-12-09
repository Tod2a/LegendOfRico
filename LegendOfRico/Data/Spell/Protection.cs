namespace LegendOfRico.Data;

public class Protection : Spells
{
    public override string SpellName { get; protected set; } = "Protection (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            player.SetProtectDuration(10);
            if(player.PartyMember != null) 
            { 
                player.PartyMember.SetProtectDuration(3);
                s += player.Name + " lance Protection sur votre groupe ! ";
            }
            else
            {
                s += player.Name + " se protège ! ";
            }
            CurrentNumberOfUses--;
            SpellName = "Protection (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}