namespace LegendOfRico.Data;

public class Steal : Spells
{
    public override string SpellName => "Voler";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override void UseSpell(Game currentGame)
    {
        if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Humanoid)
        {
            var t = (Humanoid)currentGame.MonsterFight;
            currentGame.Player.LootGold(t.DropsCoins());
            CurrentNumberOfUses--;
        }
    }
}