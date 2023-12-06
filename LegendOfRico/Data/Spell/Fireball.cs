namespace LegendOfRico.Data;

public class Fireball : Spells
{
    public override string SpellName { get; protected set; } = "Boule de feu (15/15)";
    public override int MaxNumberOfUses => 15;
    public override int CurrentNumberOfUses { get; protected set; } = 15;
    public int MinValue => 10;
    public int MaxValue => 15;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double CritChance = 0.05;
    public double BurnChance = 0.2;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if(CurrentNumberOfUses > 0)
        {
            int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
            damageRoll += (int)((currentGame.Player.Statistics / 50) * damageRoll);

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
            SpellName = "Boule de feu ("+CurrentNumberOfUses+"/"+MaxNumberOfUses+")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}