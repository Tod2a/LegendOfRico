namespace LegendOfRico.Data;

public class Burst : Spells
{
    public override string SpellName { get; protected set; } = "Explosion (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            s += player.Name+" frappe la cible deux fois dans un excès de rage ! ";
            player.Hit(target);
            player.Hit(target);
            CurrentNumberOfUses--;
            SpellName = "Explosion (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}