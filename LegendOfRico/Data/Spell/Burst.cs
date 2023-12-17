namespace LegendOfRico.Data;

public class Burst : Spells
{
    public override string SpellName { get; protected set; } = "Explosion (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    protected override string SpellEffect(Character player, Monster target)
    {
        player.Hit(target);
        player.Hit(target);
        CurrentNumberOfUses--;
        SpellName = "Explosion (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        return player.Name + " frappe la cible deux fois dans un excès de rage ! ";
    }
}