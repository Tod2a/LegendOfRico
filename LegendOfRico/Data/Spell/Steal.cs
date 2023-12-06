namespace LegendOfRico.Data;

public class Steal : Spells
{
    public override string SpellName { get; protected set; } = "Voler (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if(CurrentNumberOfUses > 0)
        {
            if (target.MonsterType == TypeOfMonster.Humanoid)
            {
                var t = (Humanoid)target;
                int stolenCoins = t.DropsCoins();
                player.LootGold(stolenCoins);
                CurrentNumberOfUses--;
                SpellName = "Voler (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
                s += player.Name + " a volé " + stolenCoins + " à la cible !";
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
        player.SetIsRested(false);
        return s;
    }
}