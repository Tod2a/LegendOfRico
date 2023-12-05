namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; protected set; } = new Mace("Masse en bois","(1 - 3)", 5, 1, 3, 0);
    public override Stuff CharacterShield { get; protected set; } = new Shield("Bouclier en bois", "Armure : 3", 0, 3);
    public override Stuff CharacterArmor { get; protected set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; protected set; } = true;
    public override int MaxHitPoints => 25;
    public override int CurrentHitPoints { get; set; } = 25;
    public override int ArmorAmount { get; protected set; } = 4;
    public override double ChanceToDodge { get; protected set; } = 0.05;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Smite(), new Heal()};
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";

   protected override void CheckLearnSpell() 
    {
        if (Level == 3)
        {
            //Spell à définir
        }
    }
}