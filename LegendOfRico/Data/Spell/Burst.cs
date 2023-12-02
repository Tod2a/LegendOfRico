namespace LegendOfRico.Data;

public class Burst : Spells
{
    public override string SpellName => "Explosion";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public TypeOfDamage SpellType = TypeOfDamage.None;

    public override string UseSpell(Game currentGame)
    {
        currentGame.Player.Hit(currentGame.MonsterFight);
        currentGame.Player.Hit(currentGame.MonsterFight);
        CurrentNumberOfUses--;
        return "Vous frappez votre cible deux fois dans un excès de rage !";
    }
}