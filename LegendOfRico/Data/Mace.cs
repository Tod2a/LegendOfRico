
namespace LegendOfRico.Data
{
    public class Mace : Weapon
    {
        public Mace(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage, Dictionary<Stats, int> bonusStats) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }

        public Mace(string itemName, int price, int minimumWeaponDamage, int maximumWeaponDamage) :
            base(itemName, price, minimumWeaponDamage, maximumWeaponDamage)
        {
        }

        public override TypeOfWeapon WeaponType => TypeOfWeapon.Mace;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Bludgeoning;
        public override double WeaponCritChance => 0.05;
    }
}
