namespace LegendOfRico.Data;

public abstract class Humanoid : Monster
{

    public override string MonsterName { get; set; }

    public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Humanoid;
    public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bandit;
    public override int MonsterHP { get; set; } 
    public override int MonsterCurrentHP { get; set; }
    public override string fightImgUrl { get; set; }
    public override int XpGranted { get; set; }
    public int MinCoins { get; private set; }
    public int MaxCoins { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None };

    public Humanoid()
    {
        HitTable = BuildHitTable();
    }

    protected abstract MonsterHit[] BuildHitTable();


    public int DropsCoins()
    {
        return (new Random()).Next(MinCoins, MaxCoins + 1);
    }
}