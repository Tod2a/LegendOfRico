namespace LegendOfRico.Data;

public class Sooth : Spells
{
    public override string SpellName { get; protected set; } = "Apaiser (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;

    protected override string SpellEffect(Character player, Monster target)
    {
        if (target.MonsterType == TypeOfMonster.Beast)
        {
            var t = (Beast)target;
            t.Soothed();
            CurrentNumberOfUses--;
            SpellName = "Apaiser (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            return player.Name + " a apaisé la cible !";
        }
        else
        {
            return "Vous ne pouvez apaiser que les bêtes !";
        }
    }
}