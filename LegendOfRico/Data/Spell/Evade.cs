namespace LegendOfRico.Data;

public class Evade : Spells
{
    public override string SpellName { get; protected set; } = "Evasion (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    protected override string SpellEffect(Character player, Monster target)
    {
        player.SetEvadeDuration(5);
        CurrentNumberOfUses--;
        SpellName = "Evasion (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        return player.Name + " se fond dans les ombres et devient intouchable ! ";
    }
}