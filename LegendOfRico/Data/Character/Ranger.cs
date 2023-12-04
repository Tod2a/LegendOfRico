namespace LegendOfRico.Data;

public class Ranger : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Weapon CharacterWeapon { get; protected set; } = new Bow("Arc en bois flotté", "arc", 5, 3, 4);
    public override Shield CharacterShield { get; protected set; } = new FistShield("Poing", "poing", 0, 0);
    public override Armor CharacterArmor { get; protected set; } = new Armor("Haillons", "haillons", 5, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; protected set; } = false;
    public override int MaxHitPoints { get; } = 10000;
    public override int CurrentHitPoints { get; set; } = 10000;
    public override int ArmorAmount { get; protected set; } = 1;
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