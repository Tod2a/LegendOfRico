namespace LegendOfRico.Data;

public class Incinerate : Spells
{
    public override string SpellName { get; protected set; } = "Incinérer (10/10)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Fire;
    public double BurnChance = 0.8;

    protected override string SpellEffect(Character player, Monster target)
    {
        CurrentNumberOfUses--;
        SpellName = "Incinérer (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        if ((new Random()).NextDouble() <= BurnChance && !IsResistant(target))
        {
            target.Incinerate();
            return player.Name + " incinère votre cible ! ";
        }
        else
        {
            return "Incinérer échoue ! ";
        }
    }
}