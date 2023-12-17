namespace LegendOfRico.Data;

public class Assassinate : Spells
{
    public override string SpellName { get; protected set; } = "Assassiner (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    protected override string SpellEffect(Character player, Monster target)
    {
        if(new Random().NextDouble() <= 0.75 && !IsABoss(target))
        {
            target.TakeDamage(target.MonsterCurrentHP);
            CurrentNumberOfUses--;
            SpellName = "Assassiner (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            return player.Name + " assassine la cible ! ";
        }
        else
        {
            return player.Name + " tente d'assassiner la cible mais échoue ! ";
        }
    }
}