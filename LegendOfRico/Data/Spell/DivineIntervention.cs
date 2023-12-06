namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName { get; protected set; } = "Intervention divine (2/2)";
    public override int MaxNumberOfUses => 2;
    public override int CurrentNumberOfUses { get; protected set; } = 2;
    public int MinValue => 60;
    public int MaxValue => 80;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

            int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
            healRoll += (int)((currentGame.Player.Statistics / 50) * healRoll);

            currentGame.MonsterFight.TakeDamage(damageRoll);
            currentGame.Player.ReceiveHeal(healRoll);

            if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Undead)
            {
                currentGame.MonsterFight.Burnt();
                currentGame.MonsterFight.TakeDamage((int)(currentGame.MonsterFight.MonsterHP / 10));
                s += s += "Votre cible brûle ! ";
            }
            s += "Vous infligez " + damageRoll + " points de dégâts à la cible et rendez " + healRoll + " points de vie à vos alliés !";
            CurrentNumberOfUses--;
            SpellName = "Intervention divine (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")s";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}