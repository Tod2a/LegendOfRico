namespace LegendOfRico.Data;
public class Undead : Monster
{
   
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy, TypeOfDamage.Bludgeoning };
}