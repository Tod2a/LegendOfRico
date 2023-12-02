namespace LegendOfRico.Data;

public class Pyroblast : Spells
{
    public override string SpellName => "Explosion pyrotechnique";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public int MinValue => 70;
    public int MaxValue => 100;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.1;
    public double BurnChance = 0.5;

    public override void UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);
        currentGame.MonsterFight.TakeDamage(damageRoll);

        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= BurnChance && !currentGame.MonsterFight.MonsterResistance.Contains(SpellType))
        {
            currentGame.MonsterFight.Burnt();
        }
        currentGame.MonsterFight.TakeDamage(damageRoll);
        CurrentNumberOfUses--;
    }
}