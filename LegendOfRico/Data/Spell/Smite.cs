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
            damageRoll += (int)((player.Statistics / 50) * damageRoll);

            target.TakeDamage(damageRoll);
            if (target.MonsterType == TypeOfMonster.Undead)
            {
                target.Burnt();
                target.TakeDamage((int)(target.MonsterHP / 10));
                s += "Votre cible brûle ! ";
            }
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