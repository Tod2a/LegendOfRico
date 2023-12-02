namespace LegendOfRico.Data;

public class Steal : Spells
{
    public override string SpellName => "Voler";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Humanoid)
        {
            var t = (Humanoid)currentGame.MonsterFight;
            int stolenCoins = t.DropsCoins();
            currentGame.Player.LootGold(stolenCoins);
            CurrentNumberOfUses--;
            return "Vous avez volé "+stolenCoins+" à la cible !";
        }
        else
        {
            return "Votre cible n'a pas d'argent !";
        }
    }
}