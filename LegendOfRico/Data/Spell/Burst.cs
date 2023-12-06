namespace LegendOfRico.Data;

public class Burst : Spells
{
    public override string SpellName { get; protected set; } = "Explosion (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            s += "Vous frappez votre cible deux fois dans un excès de rage !";
            currentGame.Player.Hit(currentGame.MonsterFight);
            currentGame.Player.Hit(currentGame.MonsterFight);
            CurrentNumberOfUses--;
            SpellName = "Explosion (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        currentGame.Player.SetIsRested(false);
        return s;
    }
}