namespace LegendOfRico.Data;

public abstract class Humanoid : Monster
{

    public override string MonsterName { get; set; }
    public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Humanoid;
    public override int MonsterHP { get; set; } 
    public override int MonsterCurrentHP { get; set; }
    public override string fightImgUrl { get; set; }
    public override int XpGranted { get; set; }
    public abstract int MinCoins { get; protected set; }
    public abstract int MaxCoins { get; protected set; }
    public override TypeOfDamage[] MonsterResistance => new TypeOfDamage[] { };
    
    //Fonction propre au humanoïdes qui peuvent se faire voler de l'argent par le Rogue
    public int DropsCoins()
    {
        return (new Random()).Next(MinCoins, MaxCoins + 1);
    }
}