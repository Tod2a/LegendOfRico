namespace LegendOfRico.Data;
public class Undead : Monster
{
    public override string MonsterName { get; set; } 
    public override int MonsterMinDamage { get; set; } 
    public override int MonsterMaxDamage { get; set; } 
    public override int MonsterHP { get; set; }
    public override int MonsterCurrentHP { get; set; } 
    public override string fightImgUrl { get; set; }
    public override int XpGranted { get; set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy, TypeOfDamage.Bludgeoning };
}