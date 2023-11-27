
namespace LegendOfRico.Data
{
    public class Axe : Weapon
    {
        public Axe(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, Dictionary<Stats, int> bonusStats) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Axe(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Axe;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.10;
    }
}
