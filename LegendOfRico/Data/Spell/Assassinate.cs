namespace LegendOfRico.Data;

public class Assassinate : Spells
{
    public override string SpellName { get; protected set; } = "Assassiner (3/3)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override TypeOfDamage SpellType { get; protected set; } = TypeOfDamage.None;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if(new Random().NextDouble() <= 0.75 && target.GetType() != typeof(Sunwukong) && target.GetType() != typeof(Cheftontaton) && 
                target.GetType() != typeof(EternalScorpio) && target.GetType() != typeof(JoyBean) && target.GetType() != typeof(RicoChico))
            {
                target.TakeDamage(target.MonsterCurrentHP);
                s += player.Name + " assassine la cible ! ";
                CurrentNumberOfUses--;
                SpellName = "Assassiner (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            }
            else
            {
                s += player.Name + " tente d'assassiner la cible mais échoue ! ";
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