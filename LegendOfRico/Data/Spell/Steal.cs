namespace LegendOfRico.Data;

public class Steal : Spells
{
    public override string SpellName { get; protected set; } = "Voler (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    protected override string SpellEffect(Character player, Monster target)
    {
        if (target.MonsterType == TypeOfMonster.Humanoid)
        {
            var t = (Humanoid)target;
            int stolenCoins = t.DropsCoins();
            if (player.IsMainCharacter)
            {
                player.LootGold(stolenCoins);
            }
            else
            {
                player.PartyMember.LootGold(stolenCoins);
            }
            CurrentNumberOfUses--;
            SpellName = "Voler (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            return player.Name + " a volé " + stolenCoins + " pièces à la cible !";
        }
        else
        {
            return "Votre cible n'a pas d'argent !";
        }
    }
}