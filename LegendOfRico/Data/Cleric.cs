namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override TypeOfWeapon[] WeaponMastery { get; } = new[] { TypeOfWeapon.Axe, TypeOfWeapon.Sword };
    public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Medium;
    public Shield ClericShield { get; private set; }
    public Dictionary<Spells, int> SpellBook { get; private set; }

    public void InitializeSpellBook()
    {
        Spells ClericSmite = new Smite();
        Spells ClericHeal = new Heal();
        SpellBook.Add(ClericSmite, ClericSmite.MaxNumberOfUses);
        SpellBook.Add(ClericHeal, ClericHeal.MaxNumberOfUses);
    }
}