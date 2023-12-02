namespace LegendOfRico.Data;

public class Humanoid : Monster
{
    public int MinCoins { get; private set; }
    public int MaxCoins { get; private set; }
    public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None };


    public int DropsCoins()
    {
        return (new Random()).Next(MinCoins, MaxCoins + 1);
    }
}