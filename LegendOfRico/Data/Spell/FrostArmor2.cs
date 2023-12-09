namespace LegendOfRico.Data;

public class FrostArmor2 : Spells
{
    public override string SpellName { get; protected set; } = "Armure de givre (1/1)";
    public override int MaxNumberOfUses => 1;
    public override int CurrentNumberOfUses { get; protected set; } = 1;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if (CurrentNumberOfUses > 0)
        {
            player.SetHasFrostArmor(5);
            CurrentNumberOfUses--;
            SpellName = "Armure de givre (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}