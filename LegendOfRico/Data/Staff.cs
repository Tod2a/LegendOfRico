
namespace LegendOfRico.Data
{
    public class Staff : Weapon
    {
        public Staff(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) : 
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Staff(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Staff;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Bludgeoning;
        public override double WeaponCritChance => 0.01;
    }
}
