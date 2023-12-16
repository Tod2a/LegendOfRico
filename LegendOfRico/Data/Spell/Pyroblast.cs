namespace LegendOfRico.Data;

public class Pyroblast : Spells
{
    public override string SpellName { get; protected set; } = "Explosion pyrotechnique (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public int MinValue => 70;
    public int MaxValue => 100;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.Fire;
    public double CritChance = 0.1;
    public double BurnChance = 0.25;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        if(CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)((player.Statistics / 50) * damageRoll);

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
            SpellName = "Explosion pyrotechnique (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}