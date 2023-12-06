namespace LegendOfRico.Data;

public class Rogue : Character
{
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> {TypeOfWeapon.Dagger, TypeOfWeapon.Sword };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; protected set; } = new Dagger("Dague en bois", "(2 - 3)", 5, 3, 4, 0);
    public override Stuff CharacterShield { get; protected set; } = new FistShield("Poing", "poing", 0, 0);
    public override Stuff CharacterArmor { get; protected set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; protected set; } = false;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Steal() };
    public override int MaxHitPoints { get; protected set; } = 15;
    public override int CurrentHitPoints { get; set; } = 15;
    public override int ArmorAmount { get; protected set; } = 1;
    public override double ChanceToDodge { get; protected set; } = 0.25;
    public override string fightImgUrl { get; } = "img/Character/fightRogue.png";
    public override int Statistics { get; protected set; } = 0;


    protected override void CheckLearnSpell()
    {
        MaxHitPoints += MaxHitPoints/10 + Level;
        Statistics += (5 + Level)/2;
        if (Level == 3)
        {
            //Spell à défini
        }
    }
}