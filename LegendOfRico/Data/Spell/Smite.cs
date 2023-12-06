namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName { get; protected set; } = "Châtiment (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 10;
    public int MaxValue => 20;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

            currentGame.MonsterFight.TakeDamage(damageRoll);
            if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Undead)
            {
                currentGame.MonsterFight.Burnt();
                currentGame.MonsterFight.TakeDamage((int)(currentGame.MonsterFight.MonsterHP / 10));
                s += "Votre cible brûle ! ";
            }
            s += "Vous infligez " + damageRoll + " points de dégâts à la cible !";
            CurrentNumberOfUses--;
            SpellName = "Châtiment (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}