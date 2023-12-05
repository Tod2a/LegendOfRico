namespace LegendOfRico.Data
{
    public class DoubleWeapon : Weapon
    {
        public Stuff Weapon1 { get; set; }
        public Stuff Weapon2 { get; set; }
        public override TypeOfWeapon WeaponType => TypeOfWeapon.Dagger;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance => 0.20;

        public DoubleWeapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats, Stuff weapon1, Stuff weapon2) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
            Weapon1 = weapon1;
            Weapon2 = weapon2;
        }
    }
}
