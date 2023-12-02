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

    public override string UseSpell(Game currentGame)
    {
        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);
        string s = "";

        if ((new Random()).NextDouble() <= CritChance)
        {
            damageRoll *= 2;
            s += "Coup critique ! ";
        }
        if ((new Random()).NextDouble() <= BurnChance && !currentGame.MonsterFight.MonsterResistance.Contains(SpellType))
        {
            currentGame.MonsterFight.Burnt();
            s += "Votre cible brûle ! ";
        }
        currentGame.MonsterFight.TakeDamage(damageRoll);
        s += "Vous infligez " + damageRoll + " points de dégâts à la cible ! ";
        CurrentNumberOfUses--;
        return s;
    }
}