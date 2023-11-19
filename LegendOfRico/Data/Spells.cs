namespace LegendOfRico.Data;

public abstract class Spells
{
    public abstract string SpellName { get; }
    public abstract int MaxNumberOfUses { get; }
    public abstract int MinValue { get; }
    public abstract int MaxValue { get; }
}