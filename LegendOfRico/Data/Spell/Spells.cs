namespace LegendOfRico.Data;

public abstract class Spells
{
    public abstract string SpellName { get; }
    public abstract int MaxNumberOfUses { get; }
    public abstract int CurrentNumberOfUses { get; protected set; }

    public void RefreshSpell()
    {
        CurrentNumberOfUses = MaxNumberOfUses;
    }

    public abstract string UseSpell(Game currentGame);
}