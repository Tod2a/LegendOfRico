namespace LegendOfRico.Data;

public class Cleanse : Spells
{
    public override string SpellName { get; protected set; } = "Purifier (10/10)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if (CurrentNumberOfUses > 0)
        {
            player.HealAffliction();
            if (player.PartyMember != null)
            {
                player.PartyMember.HealAffliction();
                s += player.Name + " purifie le groupe de ses afflictions ! ";
            }
            else
            {
                s += player.Name + " se purifie de ses afflictions ! ";
            }

            CurrentNumberOfUses--;
            SpellName = "Purifier (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}