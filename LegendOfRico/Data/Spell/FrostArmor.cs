namespace LegendOfRico.Data;

public class FrostArmor : Spells
{
    public override string SpellName { get; protected set; } = "Armure de glace (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Cold;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if (CurrentNumberOfUses > 0)
        {
            player.SetHasFrostArmor(2);
            CurrentNumberOfUses--;
            SpellName = "Armure de glace (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}