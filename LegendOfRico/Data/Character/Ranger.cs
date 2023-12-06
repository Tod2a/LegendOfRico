namespace LegendOfRico.Data;

public class Ranger : Character
{
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; set; } = new Bow("Arc en bois flotté", "(3 - 4)", 5, 3, 4, 0);
    public override Stuff CharacterShield { get; set; } = new FistShield("Poing", "poing", 0, 0);
    public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; set; } = false;
    public override int MaxHitPoints { get; protected set; } = 20;
    public override int CurrentHitPoints { get; set; } = 20;
    public override int ArmorAmount { get; set; } = 1;
    public override double ChanceToDodge { get; protected set; } = 0.15;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Sooth(), new Tame()};
    public override Beast Pet { get; protected set; } = new Bulldog();
    public override string fightImgUrl { get; } = "img/Character/fightRanger.png";
    public override int Statistics { get; set; } = 0;

    protected override void CheckLearnSpell()
    {
        if (Level == 3)
        {
            //Spell à défini
        }
    }

    public override string Hit (Monster target)
    {
        string s = base.Hit (target);
        int petDamage = new Random ().Next (Pet.PetMinDamage, Pet.PetMaxDamage+1);
        target.TakeDamage(petDamage);
        s += "votre fidèle compagnon inflige " + petDamage + " dégats à la cible.";
        return s;

    }

    public void NewPetTamed(Beast newPet)
    {
        Pet = newPet;
    }
}