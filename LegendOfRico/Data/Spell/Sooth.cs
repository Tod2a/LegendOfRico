namespace LegendOfRico.Data;

public class Sooth : Spells
{
    public override string SpellName { get; protected set; } = "Apaiser (5/5)";
    public override int MaxNumberOfUses => 5;
    public override int CurrentNumberOfUses { get; protected set; } = 5;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;

    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if (target.MonsterType == TypeOfMonster.Beast)
            {
                var t = (Beast)target;
                t.Soothed();
                CurrentNumberOfUses--;
                SpellName = "Apaiser (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
                s += player.Name + " a apaisé la cible !";
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
        player.SetIsRested(false);
        return s;
    }
}