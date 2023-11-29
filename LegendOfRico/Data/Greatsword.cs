
namespace LegendOfRico.Data
{
    public class Greatsword : Weapon
    {
        public Greatsword(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Greatsword(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Greatsword;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.1;
    }
}