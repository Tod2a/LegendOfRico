namespace LegendOfRico.Data;

public abstract class Beast : Monster
{
    public Boolean isSoothed { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Fire };


    public void Soothed()
    {
        isSoothed = true;
    }
}