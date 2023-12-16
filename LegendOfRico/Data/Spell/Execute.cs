namespace LegendOfRico.Data;

public class Execute : Spells
{
    public override string SpellName { get; protected set; } = "Exécuter (5/5)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override TypeOfDamage SpellType { get; protected set; }
    public double CritChance = 0.1;
    public override string UseSpell(Character player, Monster target)
    {
        string s = "";
        if (CurrentNumberOfUses > 0)
        {
            if(target.MonsterCurrentHP <= target.MonsterHP / 3)
            {
                SpellType = player.CharacterWeapon.WeaponTypeOfDamage;
                int damageRoll = new Random().Next(player.CharacterWeapon.MinimumWeaponDamage, player.CharacterWeapon.MaximumWeaponDamage + 1);
                damageRoll *= 3;
                target.TakeDamage(damageRoll);
                s += player.Name + " exécute la cible et lui inflige " + damageRoll + " points de dégâts ! ";
                CurrentNumberOfUses--;
                SpellName = "Exécuter (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            }
            else
            {
                s += "La cible n'est pas encore à portée d'exécution. Vous attaquez normalement. ";
                s += player.Hit(target);
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