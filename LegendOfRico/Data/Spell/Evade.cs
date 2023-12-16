namespace LegendOfRico.Data;

public class Evade : Spells
{
    public override string SpellName { get; protected set; } = "Evasion (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            player.SetEvadeDuration(5);
            CurrentNumberOfUses--;
            SpellName = "Evasion (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            s += player.Name + " se fond dans les ombres et devient intouchable ! ";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}