namespace LegendOfRico.Data;

public class DivineIntervention : Spells
{
    public override string SpellName => "Divine Intervention";
    public override int MaxNumberOfUses => 2;
    public override int CurrentNumberOfUses { get; protected set; } = 2;
    public int MinValue => 60;
    public int MaxValue => 80;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

        int healRoll = (new Random()).Next(MinValue, MaxValue + 1);
        healRoll += (int)((currentGame.Player.Statistics / 50) * healRoll);
        string s = "";

        currentGame.MonsterFight.TakeDamage(damageRoll);
        currentGame.Player.ReceiveHeal(healRoll);

        if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Undead)
        {
            currentGame.MonsterFight.Burnt();
            currentGame.MonsterFight.TakeDamage((int)(currentGame.MonsterFight.MonsterHP / 10));
            s += s += "Votre cible brûle ! ";
        }
        s += "Vous infligez " + damageRoll + " points de dégâts à la cible et rendez "+healRoll+" points de vie à vos alliés !";
        CurrentNumberOfUses--;
        return s;
    }
}