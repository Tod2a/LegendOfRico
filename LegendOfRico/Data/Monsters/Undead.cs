namespace LegendOfRico.Data;
public abstract class Undead : Monster
{
    public override string MonsterName { get; set; } 

    public override MonsterHit[] HitTable { get; set; }
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Undead;
    public override int MonsterHP { get; set; }
    public override int MonsterCurrentHP { get; set; } 
    public override string fightImgUrl { get; set; }
    public override int XpGranted { get; set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy, TypeOfDamage.Bludgeoning };
    public override TypeOfDamage[] MonsterResistance => new TypeOfDamage[] { };
}