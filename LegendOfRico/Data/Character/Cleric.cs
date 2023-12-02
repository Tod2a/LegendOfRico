namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override bool CanEquipShield { get; protected set; } = true;
    public override int MaxHitPoints => 25;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Smite(), new Heal(),};
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";

    public override void Rest()
    {
        base.Rest();
        foreach (var spell in SpellBook)
        {
            spell.RefreshSpell();
        }
    }
}