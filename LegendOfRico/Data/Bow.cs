
namespace LegendOfRico.Data
{
    public class Bow : Weapon
    {
        public Bow(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, Dictionary<Stats, int> bonusStats) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Bow(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Bow;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Piercing;
        public override double WeaponCritChance => 0.15;
    }
}
