namespace LegendOfRico.Data;

public class Rogue : Character
{
    //D�finition des Points de vie de base du rogue
    public override int MaxHitPoints { get; set; } = 15;
    public override int CurrentHitPoints { get; set; } = 15;
    //D�finition du stuff de base du rogue, ce qu'il peut porter, tout ce qui est utile au combat
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> {TypeOfWeapon.Dagger, TypeOfWeapon.Sword };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; set; } = new Fist("Poing", "un poing", 0, 1, 3, 0);
    public override Stuff CharacterShield { get; set; } = new FistShield("Poing", "poing", 0, 0);
    public override Stuff CharacterArmor { get; set; } = new Topless("Rien", "Bah rien", 0, TypeOfArmor.None, 0);
    public override bool CanEquipShield { get; set; } = false;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Steal() };
    public override int ArmorAmount { get; set; } = 1;
    public override double ChanceToDodge { get; protected set; } = 0.25;
    public override string fightImgUrl { get; } = "img/Character/fightRogue.png";
    public override int Statistics { get; set; } = 0;

    // Utilisation de la fonction abstraite cr��e dans Character affin d'apprendre les sorts et faire gagner les stats
    protected override void CheckLearnSpell()
    {
        int gainedHP = MaxHitPoints / 10 + Level;
        CurrentHitPoints += gainedHP;
        MaxHitPoints += gainedHP;
        Statistics += (7 + Level)/2;

        if (Level == 3)
        {
            SpellBook.Add(new Evade());
        }
        if( Level == 5)
        {
            SpellBook.Add(new Assassinate());
        }
    }
}