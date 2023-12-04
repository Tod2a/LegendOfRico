namespace LegendOfRico.Data;

public abstract class Beast : Monster
{
    public Boolean isSoothed { get; private set; }
    public int SoothDuration { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Fire };
    public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };


    public void Soothed()
    {
        isSoothed = true;
        SoothDuration = 5;
    }
}