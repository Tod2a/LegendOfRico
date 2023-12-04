namespace LegendOfRico.Data;

public class Steal : Spells
{
    public override string SpellName => "Voler";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if(CurrentNumberOfUses > 0)
        {
            if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Humanoid)
            {
                var t = (Humanoid)currentGame.MonsterFight;
                int stolenCoins = t.DropsCoins();
                currentGame.Player.LootGold(stolenCoins);
                CurrentNumberOfUses--;
                s += "Vous avez volé " + stolenCoins + " à la cible !";
            }
            else
            {
                s += "Votre cible n'a pas d'argent !";
            }
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        return s;
    }
}