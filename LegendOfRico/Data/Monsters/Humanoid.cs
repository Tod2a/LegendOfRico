namespace LegendOfRico.Data;

public class Humanoid : Monster
{

    public override string MonsterName { get; set; } 

    public override MonsterHit[] HitTable { get; set; }
    public override int MonsterHP { get; set; } 
    public override int MonsterCurrentHP { get; set; }
    public override string fightImgUrl { get; set; }
    public override int XpGranted { get; set; }
    public int MinCoins { get; private set; }
    public int MaxCoins { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None };


    public int DropsCoins()
    {
        return (new Random()).Next(MinCoins, MaxCoins + 1);
    }
}