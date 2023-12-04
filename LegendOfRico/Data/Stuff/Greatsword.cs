
namespace LegendOfRico.Data
{
    public class Greatsword : Weapon
    {
        public Greatsword(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Greatsword;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.1;
    }
}