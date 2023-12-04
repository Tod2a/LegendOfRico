namespace LegendOfRico.Data;

public class Rogue : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] {TypeOfWeapon.Dagger, TypeOfWeapon.Sword };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public override Stuff CharacterWeapon { get; protected set; } = new Dagger("Dague en bois", "dague", 5, 1, 3);
    public override Stuff CharacterShield { get; protected set; } = new FistShield("Poing", "poing", 0, 0);
    public override Stuff CharacterArmor { get; protected set; } = new Armor("Haillons", "aillons", 5, TypeOfArmor.Light, 1);
    public Weapon OffHandWeapon { get; private set; } = new Fist("Poing", "poing", 0, 1, 3);
    public override bool CanEquipShield { get; protected set; } = false;
    public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Steal() };
    public override int MaxHitPoints => 15;
    public override int CurrentHitPoints { get; set; } = 15;
    public override int ArmorAmount { get; protected set; } = 1;
    public override double ChanceToDodge { get; protected set; } = 0.25;
    public override string fightImgUrl { get; } = "img/Character/fightRogue.png";


    protected override void CheckLearnSpell()
    {
        if (Level == 3)
        {
            //Spell à défini
        }
    }

    //Special "Hit" for Rogue since he can wield two weapons at once
    public override void Hit(Monster target)
    {
        int weaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        weaponDamageRoll += (int)((Statistics / 50) * weaponDamageRoll);
        if (!(OffHandWeapon.GetType() == typeof(Fist))) //Adds half off hand weapon damage to the damage roll
        {
            int offHandWeaponDamageRoll = 
                (int)(new Random()).Next(OffHandWeapon.MinimumWeaponDamage, OffHandWeapon.MaximumWeaponDamage + 1) / 2;
            offHandWeaponDamageRoll += (int)((Statistics / 50) * offHandWeaponDamageRoll);
            weaponDamageRoll += offHandWeaponDamageRoll;
        }
        
        if ((new Random()).NextDouble() <= CharacterWeapon.WeaponCritChance) //Double damage if crit
        {
            weaponDamageRoll *= 2;
        }

        if (target.MonsterWeakness.Contains(CharacterWeapon.WeaponTypeOfDamage)) //Double damage if weakness
        {
            weaponDamageRoll *= 2;
        }
        target.TakeDamage(weaponDamageRoll);
    }
    
    public void EquipOffHandWeapon(Weapon weapon)
    {
        StuffInventory.Remove(weapon);
        OffHandWeapon = weapon;
    }

    public void UnequipOffHandWeapon()
    {
        StuffInventory.Add(OffHandWeapon);
        OffHandWeapon = new Fist("Poing", "poing", 0, 1, 3);
    }
}