namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName { get; protected set; } = "Châtiment (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 10;
    public int MaxValue => 20;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += player.Statistics / 50 * damageRoll;

            target.TakeDamage(damageRoll);
            if (target.MonsterType == TypeOfMonster.Undead)
            {
                target.Burnt();
                s += "Votre cible brûle ! ";
            }
            if (target.MonsterResistance.Contains(SpellType))
            {
                damageRoll /= 2;
                s += "Peu efficace ! ";
            }
            else if (target.MonsterWeakness.Contains(SpellType))
            {
                damageRoll *= 2;
                s += "Efficace ! ";
            }
            target.TakeDamage(damageRoll);
            s += player.Name + " inflige " + damageRoll + " points de dégâts à la cible !";
            CurrentNumberOfUses--;
            SpellName = "Châtiment (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}