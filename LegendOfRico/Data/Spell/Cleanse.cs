namespace LegendOfRico.Data;

public class Cleanse : Spells
{
    public override string SpellName { get; protected set; } = "Purifier (10/10)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    protected override string SpellEffect(Character player, Monster target)
    {
        player.HealAffliction();
        CurrentNumberOfUses--;
        SpellName = "Purifier (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        if (player.PartyMember != null)
        {
            player.PartyMember.HealAffliction();
            return player.Name + " purifie le groupe de ses afflictions ! ";
        }
        else
        {
            return player.Name + " se purifie de ses afflictions ! ";
        }
    
    }
}