namespace LegendOfRico.Data;

public class Frostbolt : Spells
{
    public override string SpellName => "Frostbolt";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 15;
    public int MaxValue => 25;
    public TypeOfDamage SpellType = TypeOfDamage.Cold;
    public double CritChance = 0.2;
    public double FreezeChance = 0.05;

    public override void UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
        }
        if ((new Random()).NextDouble() <= FreezeChance && !currentGame.MonsterFight.MonsterResistance.Contains(SpellType))
        {
            currentGame.MonsterFight.Frozen();
        }
        currentGame.MonsterFight.TakeDamage(damageRoll);
        CurrentNumberOfUses--;
    }
}