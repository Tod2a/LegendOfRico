namespace LegendOfRico.Data;

public class Fireball : Spells
{
    public override string SpellName => "Fireball";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 10;
    public int MaxValue => 30;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.05;
    public double BurnChance = 0.2;

    public override void UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= BurnChance && !currentGame.MonsterFight.MonsterResistance.Contains(SpellType))
        {
            currentGame.MonsterFight.Burnt();
        }
        currentGame.MonsterFight.TakeDamage(damageRoll);
    }
}