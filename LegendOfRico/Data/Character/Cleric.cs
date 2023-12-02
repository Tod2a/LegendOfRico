namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Weapon CharacterWeapon { get; protected set; } = new Mace("Masse en bois", 5, 1, 3);
    public override Shield CharacterShield { get; protected set; } = new Shield("Bouclier en bois", 0, 3);
    public override bool CanEquipShield { get; protected set; } = true;
    public override int MaxHitPoints => 25;
    public override int CurrentHitPoints { get; protected set; } = 25;
    public override int ArmorAmount { get; protected set; } = 3;
    public override double ChanceToDodge { get; protected set; } = 0.05;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Smite(), new Heal(), new Pyroblast(), new DivineIntervention()};
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";

   protected override void CheckLearnSpell() 
    {
        if (Level == 3)
        {
            //Spell à défini
        }
    }
}