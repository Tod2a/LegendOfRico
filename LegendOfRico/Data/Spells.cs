namespace LegendOfRico.Data;

public abstract class Spells
{
    public abstract string SpellName { get; }
    public abstract int MaxNumberOfUses { get; }
    public abstract int CurrentNumberOfUses { get; protected set; }
    public abstract int MinValue { get; }
    public abstract int MaxValue { get; }

    public void RefreshSpell()
    {
        CurrentNumberOfUses = MaxNumberOfUses;
    }

    public abstract void UseSpell(Monster target);
    public abstract void UseSpell(Character target);
}