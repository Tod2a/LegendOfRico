namespace LegendOfRico.Data;

public class Sooth : Spells
{
    public override string SpellName { get; protected set; } = "Apaiser (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if (currentGame.MonsterFight.MonsterType == TypeOfMonster.Beast)
            {
                var t = (Beast)currentGame.MonsterFight;
                t.Soothed();
                CurrentNumberOfUses--;
                SpellName = "Apaiser (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
                s += "Vous avez apaisé votre cible !";
            }
            else
            {
                s += "Vous ne pouvez apaiser que les bêtes !";
            }
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}