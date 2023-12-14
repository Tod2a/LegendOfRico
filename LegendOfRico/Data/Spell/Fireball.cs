namespace LegendOfRico.Data;

public class Fireball : Spells
{
    public override string SpellName { get; protected set; } = "Boule de feu (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 10;
    public int MaxValue => 15;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.05;
    public double BurnChance = 0.2;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if(CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += player.Statistics / 50 * damageRoll;

            if ((new Random()).NextDouble() <= CritChance)
            {
                damageRoll *= 2;
                s += "Coup critique ! ";
            }
            if ((new Random()).NextDouble() <= BurnChance && !target.MonsterResistance.Contains(SpellType))
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
            s += player.Name + " inflige " + damageRoll + " points de dégâts à la cible ! ";
            CurrentNumberOfUses--;
            SpellName = "Boule de feu ("+CurrentNumberOfUses+"/"+MaxNumberOfUses+")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}