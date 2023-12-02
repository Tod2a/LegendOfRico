namespace LegendOfRico.Data;

public class Sooth : Spells
{
    public override string SpellName => "Apaiser";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override void UseSpell(Game currentGame)
    {
        if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Beast)
        {
            var t = (Beast)currentGame.MonsterFight;
            t.Soothed();
        }
    }
}