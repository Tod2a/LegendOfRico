namespace LegendOfRico.Data;

public class Incinerate : Spells
{
    public override string SpellName => "Incinérer";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public TypeOfDamage SpellType = TypeOfDamage.Fire;
    public double BurnChance = 0.8;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if ((new Random()).NextDouble() <= BurnChance && !currentGame.MonsterFight.MonsterResistance.Contains(SpellType))
            {
                currentGame.MonsterFight.Incinerate();
                s += "Votre brûlez votre cible ! ";
            }
            else
            {
                s += "Incinérer échoue ! ";
            }
            CurrentNumberOfUses--;
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        return s;
    }
}