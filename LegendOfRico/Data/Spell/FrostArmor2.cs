namespace LegendOfRico.Data;

public class FrostArmor2 : Spells
{
    public override string SpellName { get; protected set; } = "Armure de givre (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Cold;

    protected override string SpellEffect(Character player, Monster target)
    {
        player.SetHasFrostArmor(5);
        CurrentNumberOfUses--;
        SpellName = "Armure de givre (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        
        return player.Name + " s'entoure d'une armure de glace ";
    }
}