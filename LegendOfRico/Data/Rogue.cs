namespace LegendOfRico.Data;

public class Rogue : Character
{
    public override TypeOfWeapon[] WeaponMastery => new[] {TypeOfWeapon.Dagger, TypeOfWeapon.Sword };
    public override TypeOfArmor ArmorMastery => TypeOfArmor.Medium;
    public Weapon OffHandWeapon { get; private set; } = new Fist();
    public override bool CanEquipShield { get; protected set; } = false;
    public override int MaxHitPoints => 15;
    public double ChanceToDodge { get; private set; } = 0.25;
    public override string fightImgUrl { get; } = "img/Character/fightRogue.png";
    
    public void Steal(Humanoid target)
    {
        Random chance = new Random();
        int a = chance.Next(1,10);
        if (a <= 6 ) 
        { 
            LootGold(target.DropsCoins());
        }
    }
    
    //Special "Hit" for Rogue since he can wield two weapons at once
    public override void Hit(Monster target)
    {
        int weaponDamageRoll =
            (new Random()).Next(CharacterWeapon.MinimumWeaponDamage, CharacterWeapon.MaximumWeaponDamage + 1);
        if (!(OffHandWeapon.GetType() == typeof(Fist))) //Adds half off hand weapon damage to the damage roll
        {
            weaponDamageRoll += 
                (int)(new Random()).Next(OffHandWeapon.MinimumWeaponDamage, OffHandWeapon.MaximumWeaponDamage + 1) / 2;
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
        Inventory.Remove(weapon);
        OffHandWeapon = weapon;
    }

    public void UnequipOffHandWeapon()
    {
        Inventory.Add(OffHandWeapon);
        OffHandWeapon = null;
    }
}