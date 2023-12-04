namespace LegendOfRico.Data.Stuff
{
    public class DoubleWeapon : Weapon
    {
        public Weapon Weapon1 { get; set; }
        public Weapon Weapon2 { get; set; }
        public override TypeOfWeapon WeaponType => TypeOfWeapon.Axe;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.20;

        public DoubleWeapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
        }
    }
}
