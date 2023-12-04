
namespace LegendOfRico.Data
{
    public class Axe : Weapon
    {
        public Axe(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Axe(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, "aillons", price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Axe;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.10;
    }
}
