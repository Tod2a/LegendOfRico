namespace LegendOfRico.Data;

public abstract class Beast : Monster
{
    public Boolean IsSoothed { get; private set; }
    public int SoothDuration { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Fire };
    public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };


    public void Soothed()
    {
        IsSoothed = true;
        SoothDuration = 5;
    }

    public int DamageSoothed(int damageToSooth)
    {
        int postSoothDamage = damageToSooth;
        if (IsSoothed)
        {
            postSoothDamage /= 2;
            SoothDuration--;
            IsSoothed = (SoothDuration <= 0) ?false:true;
        }
        return postSoothDamage;
    }
}