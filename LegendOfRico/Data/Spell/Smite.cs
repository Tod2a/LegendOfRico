namespace LegendOfRico.Data;

public class Smite : Spells
{
    public override string SpellName => "Châtiment";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 10;
    public int MaxValue => 20;
    public TypeOfDamage SpellType = TypeOfDamage.Holy;

    public override string UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);
        string s = "";

        currentGame.MonsterFight.TakeDamage(damageRoll);
        if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Undead)
        {
            currentGame.MonsterFight.Burnt();
            currentGame.MonsterFight.TakeDamage((int)(currentGame.MonsterFight.MonsterHP / 10));
            s += "Votre cible brûle ! ";
        }
        s += "Vous infligez " + damageRoll + " points de dégâts à la cible !";
        CurrentNumberOfUses--;
        return s;
    }
}