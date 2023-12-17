namespace LegendOfRico.Data;
public abstract class Undead : Monster
{
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Undead;
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy, TypeOfDamage.Bludgeoning };
    public override TypeOfDamage[] MonsterResistance => new TypeOfDamage[] { };
}