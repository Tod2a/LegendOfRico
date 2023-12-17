namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName { get; protected set; } = "Châtiment (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 10;
    public int MaxValue => 20;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Holy;

    protected override string SpellEffect(Character player, Monster target)
    {
        string s = "";

        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += player.Statistics / 50 * damageRoll;

        if (target.MonsterType == TypeOfMonster.Undead)
        {
            target.Burnt();
            s += "Votre cible brûle ! ";
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
        CurrentNumberOfUses--;
        SpellName = "Châtiment (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        return s + player.Name + " inflige " + damageRoll + " points de dégâts à la cible !";
    }
}