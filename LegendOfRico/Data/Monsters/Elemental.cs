namespace LegendOfRico.Data;

public abstract class Elemental: Monster
{
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Elemental;
    public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
}
