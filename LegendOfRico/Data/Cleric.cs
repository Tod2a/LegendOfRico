namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override bool CanEquipShield { get; protected set; } = true;
    public override int MaxHitPoints => 25;
    public List<Spells> SpellBook { get; private set; } = new List<Spells>(); //int-- à chaque utilisation du spell correspondant
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";

    public void InitializeSpellBook()
    {
        SpellBook.Add(new Smite());
        SpellBook.Add(new Heal());
    }

    public override void Rest()
    {
        base.Rest();
        foreach (var spell in SpellBook)
        {
            spell.RefreshSpell();
        }
    }
}