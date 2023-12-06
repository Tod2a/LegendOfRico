namespace LegendOfRico.Data;

public class Incinerate : Spells
{
    public override string SpellName { get; protected set; } = "Incinérer (10/10)";
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
            SpellName = "Incinérer (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}