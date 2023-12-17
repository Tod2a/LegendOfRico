namespace LegendOfRico.Data;

public class Execute : Spells
{
    public override string SpellName { get; protected set; } = "Exécuter (5/5)";
    public override int MaxNumberOfUses => 3;
    public override int CurrentNumberOfUses { get; protected set; } = 3;
    public override TypeOfDamage SpellType { get; protected set; }
    public double CritChance = 0.1;
    protected override string SpellEffect(Character player, Monster target)
    {
        if(target.MonsterCurrentHP <= target.MonsterHP / 3)
        {
            SpellType = player.CharacterWeapon.WeaponTypeOfDamage;
            int damageRoll = new Random().Next(player.CharacterWeapon.MinimumWeaponDamage, player.CharacterWeapon.MaximumWeaponDamage + 1);
            damageRoll *= 3;
            target.TakeDamage(damageRoll);
            CurrentNumberOfUses--;
            SpellName = "Exécuter (" + CurrentNumberOfUses + "/" + MaxNumberOfUses + ")";
            return player.Name + " exécute la cible et lui inflige " + damageRoll + " points de dégâts ! ";
        }
        else
        {
            return "La cible n'est pas encore à portée d'exécution. Vous attaquez normalement. " + player.Hit(target); 
        }

    }
}