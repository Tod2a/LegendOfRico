namespace LegendOfRico.Data;

public class Ranger : Character
{
    //Définition des Points de vie de base du Ranger
    public override int MaxHitPoints { get; set; } = 20;
    public override int CurrentHitPoints { get; set; } = 20;
    //Définition du stuff de base du ranger, ce qu'il peut porter, tout ce qui est utile au combat
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; set; } = new Bow("Arc en bois flotté", "(3 - 4)", 0, 3, 4, 0);
    public override Stuff CharacterShield { get; set; } = new FistShield("Poing", "poing", 0, 0);
    public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 0, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; set; } = false;
    public override int ArmorAmount { get; set; } = 1;
    public override double ChanceToDodge { get; protected set; } = 0.15;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Tame()};
    public override string fightImgUrl { get; } = "img/Character/fightRanger.png";
    public override int Statistics { get; set; } = 0;
    //variable du ranger qui sauvegarde son pet, les ranger commencent avec un Bulldog
    public override Beast Pet { get; set; } = new Bulldog();


    // Utilisation de la fonction abstraite créée dans Character affin d'apprendre les sorts et faire gagner les stats
    protected override void CheckLearnSpell()
    {
        int gainedHP = MaxHitPoints / 10 + Level;
        CurrentHitPoints += gainedHP;
        MaxHitPoints += gainedHP;
        Statistics += (5 + Level) / 2;

        if (Level == 3)
        {
            SpellBook.Add(new Sooth());
        }
    }

    //Modification de la fonction Hit pour récupérer le string que la fonction de base renvoye et lui ajouter l'attaque du familier
    public override string Hit (Monster target)
    {
        string s = base.Hit (target);
        int petDamage = new Random ().Next (Pet.PetMinDamage, Pet.PetMaxDamage+1);
        target.TakeDamage(petDamage);
        s += "votre fidèle compagnon inflige " + petDamage + " dégats à la cible.";
        return s;

    }

    //Fonction qui permets de dresser un nouveau familier
    public void NewPetTamed(Beast newPet)
    {
        Pet = newPet;
    }
}