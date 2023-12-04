
namespace LegendOfRico.Data
{
    public class Mace : Weapon
    {
        public Mace(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Mace;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Bludgeoning;
        public override double WeaponCritChance => 0.05;
    }
}
