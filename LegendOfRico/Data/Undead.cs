namespace LegendOfRico.Data;
public class Undead : Monster
{
    public string Name { get; set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy, TypeOfDamage.Bludgeoning };
}