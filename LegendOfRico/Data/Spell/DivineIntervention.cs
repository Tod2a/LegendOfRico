namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName { get; protected set; } = "Intervention divine (2/2)";
    public override int MaxNumberOfUses => 2;
    public override int CurrentNumberOfUses { get; protected set; } = 2;
    public int MinValue => 60;
    public int MaxValue => 80;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)(player.Statistics / 50 * damageRoll);

            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)(player.Statistics / 50 * healRoll);

            target.TakeDamage(damageRoll);
            player.ReceiveHeal(healRoll);

            if (target.MonsterType == TypeOfMonster.Undead)
            {
                target.Burnt();
                target.TakeDamage(target.MonsterHP / 10);
                s += s += "Votre cible brûle ! ";
            }
            s += player.Name + " inflige " + damageRoll + " points de dégâts à la cible et se rend " + healRoll + " points de vie !";
            CurrentNumberOfUses--;
            SpellName = "Intervention divine (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")s";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}