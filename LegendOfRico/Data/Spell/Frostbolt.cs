namespace LegendOfRico.Data;

public class Frostbolt : Spells
{
    public override string SpellName { get; protected set; } = "Eclair de givre (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 15;
    public int MaxValue => 25;
    public TypeOfDamage SpellType = TypeOfDamage.Cold;
    public double CritChance = 0.2;
    public double FreezeChance = 0.05;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((player.Statistics / 50) * damageRoll);

        if (CurrentNumberOfUses > 0)
        {
            if ((new Random()).NextDouble() <= CritChance)
            {
                damageRoll *= 2;
                s += "Coup critique ! ";
            }
            if ((new Random()).NextDouble() <= FreezeChance && !target.MonsterResistance.Contains(SpellType)
                && !target.IsFrozen)
            {
                target.Frozen();
                s += player.Name + " a gelé votre cible ! ";
            }
            target.TakeDamage(damageRoll);
            s += player.Name + " inflige " + damageRoll + " points de dégâts à la cible ! ";
            CurrentNumberOfUses--;
            SpellName = "Eclair de givre (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}