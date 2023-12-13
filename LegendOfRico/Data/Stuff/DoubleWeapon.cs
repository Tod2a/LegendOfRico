namespace LegendOfRico.Data
{
    public class DoubleWeapon : Weapon
    {
        public Stuff Weapon1 { get; set; }
        public Stuff Weapon2 { get; set; }
        public override TypeOfWeapon WeaponType => TypeOfWeapon.Dagger;
        public override TypeOfDamage WeaponTypeOfDamage => TypeOfDamage.Slashing;
        public override double WeaponCritChance { get; protected set; }

        public DoubleWeapon(string itemName, string description, int price, int minimumWeaponDamage, int maximumWeaponDamage, int bonusStats, Stuff weapon1, Stuff weapon2) :
            base(itemName, description, price, minimumWeaponDamage, maximumWeaponDamage, bonusStats)
        {
            Weapon1 = weapon1;
            Weapon2 = weapon2;
            ItemName = weapon1.ItemName + "/" + weapon2.ItemName;
            Description = weapon1.Description + "/" + weapon2.Description;
            Price = weapon1.Price + weapon2.Price;
            MinimumWeaponDamage = weapon1.MinimumWeaponDamage + weapon2.MinimumWeaponDamage / 2;
            MaximumWeaponDamage = weapon1.MaximumWeaponDamage + weapon2.MaximumWeaponDamage / 2;
            BonusStats = weapon1.BonusStats + weapon2.BonusStats;

            WeaponCritChance = (weapon1.WeaponCritChance + weapon2.WeaponCritChance)/2;
        }
    }
}
