namespace LegendOfRico.Data;

public abstract class Spells
{
    public abstract string SpellName { get; protected set; }
    public abstract int MaxNumberOfUses { get; }
    public abstract int CurrentNumberOfUses { get; protected set; }

    public void RefreshSpell()
    {
        CurrentNumberOfUses = MaxNumberOfUses;
        string newSpellName = SpellName.Substring(0, SpellName.IndexOf("(") +1);
        newSpellName += MaxNumberOfUses + "/" + MaxNumberOfUses + ")";
        SpellName = newSpellName;
    }

    public abstract string UseSpell(Game currentGame);
}