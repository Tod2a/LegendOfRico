namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override bool CanEquipShield { get; protected set; } = true;
    public override int MaxHitPoints => 25;
    public Dictionary<Spells, int> SpellBook { get; private set; }
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";

    public void InitializeSpellBook()
    {
        Spells ClericSmite = new Smite();
        Spells ClericHeal = new Heal();
        SpellBook.Add(ClericSmite, ClericSmite.MaxNumberOfUses);
        SpellBook.Add(ClericHeal, ClericHeal.MaxNumberOfUses);
    }
}