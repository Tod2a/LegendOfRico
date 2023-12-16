namespace LegendOfRico.Data;

public class Cleric : Character
{
    public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Mace };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; set; } = new Mace("Masse en bois","(1 - 3)", 5, 1, 3, 0);
    public override Stuff CharacterShield { get; set; } = new Shield("Bouclier en bois", "Armure : 3", 0, 3);
    public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
    public override bool CanEquipShield { get; set; } = true;
    public override int MaxHitPoints { get; protected set; } = 25;
    public override int CurrentHitPoints { get; set; } = 25;
    public override int ArmorAmount { get; set; } = 4;
    public override double ChanceToDodge { get; protected set; } = 0.05;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Smite()};
    public override string fightImgUrl { get;  } = "img/Character/fightCleric.png";
    public override int Statistics { get; set; } = 0;
    protected override void CheckLearnSpell() 
    {
        int gainedHP = MaxHitPoints / 10 + Level;
        CurrentHitPoints += gainedHP;
        MaxHitPoints += gainedHP;
        Statistics += (5 + Level) / 2;

        if(Level == 2)
        {
            SpellBook.Add(new Heal());
        }
        if(Level == 3)
        {
            SpellBook.Add(new Protection());
            SpellBook.Add(new Cleanse());
        }
        if(Level == 4)
        {
            SpellBook.Add(new GreaterHeal());
        }
        if(Level == 5)
        {
            SpellBook.Add(new SupremeHeal());
        }
        if (Level == 6)
        {
            SpellBook.Add(new Recons());
        }
        if (Level == 7)
        {
            SpellBook.Add(new DivineIntervention());
        }
    }
}