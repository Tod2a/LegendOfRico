namespace LegendOfRico.Data;

public class IceLance : Spells
{
    public override string SpellName { get; protected set; } = "Javelot de glace (15/15)";
    public override int MaxNumberOfUses => 10;
    public override int CurrentNumberOfUses { get; protected set; } = 10;
    public int MinValue => 20;
    public int MaxValue => 25;
    public TypeOfDamage SpellType = TypeOfDamage.Cold;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";

        int damageRoll = (new Random()).Next(MinValue, MaxValue + 1);
        damageRoll += (int)((player.Statistics / 50) * damageRoll);

        if (CurrentNumberOfUses > 0)
        {
            if (target.IsCold)
            {
                damageRoll *= 2;
                s += "Coup critique ! ";
                target.SetIsCold(false);
            }
            target.TakeDamage(damageRoll);
            s += player.Name + " inflige " + damageRoll + " points de dégâts à la cible ! ";
            CurrentNumberOfUses--;
            SpellName = "Javelot de glace (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
        }
        else
        {
            s += "Vous ne pouvez plus lancer ce sort !";
        }
        player.SetIsRested(false);
        return s;
    }
}