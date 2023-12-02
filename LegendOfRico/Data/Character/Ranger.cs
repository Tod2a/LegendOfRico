namespace LegendOfRico.Data;

public class Ranger : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Weapon CharacterWeapon { get; protected set; } = new Bow("Arc en bois flotté", 5, 3, 4);
    public override Shield CharacterShield { get; protected set; } = new FistShield("Poing", 0, 0);
    public override bool CanEquipShield { get; protected set; } = false;
    public override int MaxHitPoints { get; } = 20;
    public override int CurrentHitPoints { get; protected set; } = 20;
    public override int ArmorAmount { get; protected set; } = 0;
    public override double ChanceToDodge { get; protected set; } = 0.15;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Sooth()};
    public override string fightImgUrl { get; } = "img/Character/fightRanger.png";
    protected override void CheckLearnSpell()
    {
        if (Level == 3)
        {
            //Spell à défini
        }
    }
}