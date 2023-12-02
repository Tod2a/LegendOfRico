namespace LegendOfRico.Data;

public class Ranger : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override bool CanEquipShield { get; protected set; } = false;
    public override int MaxHitPoints { get; } = 20;
    public override double ChanceToDodge { get; protected set; } = 0.15;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Sooth()};
    public override string fightImgUrl { get; } = "img/Character/fightRanger.png";
}