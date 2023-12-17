namespace LegendOfRico.Data;

public class Frostbolt : Spells
{
    public override string SpellName { get; protected set; } = "Eclair de givre (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 15;
    public int MaxValue => 25;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Cold;
    public double CritChance = 0.2;
    public double FreezeChance = 0.05;

    protected override string SpellEffect(Character player, Monster target)
    {
        string s = "";

        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((player.Statistics / 50) * damageRoll);

        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
            s += "Coup critique ! ";
        }
        if ((new Random()).NextDouble() <= FreezeChance && !IsResistant(target) && !target.IsFrozen)
        {
            target.Frozen();
            s += player.Name + " a gel� votre cible ! ";
        }

        if (IsResistant(target))
        {
            damageRoll /= 2;
            s += "Peu efficace ! ";
        }
        else if (IsWeak(target))
        {
            damageRoll *= 2;
            s += "Efficace ! ";
        }
        target.TakeDamage(damageRoll);
        s += player.Name + " inflige " + damageRoll + " points de d�g�ts � la cible ! ";
        target.SetIsCold(true);
        CurrentNumberOfUses--;
        SpellName = "Eclair de givre (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
      
        return s;
    }
}