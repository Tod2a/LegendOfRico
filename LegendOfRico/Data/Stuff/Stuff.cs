namespace LegendOfRico.Data
{
    public abstract class Stuff : Item
    {
        public virtual double WeaponCritChance { get; }
        public virtual int MinimumWeaponDamage { get; protected set; }
        public virtual int MaximumWeaponDamage { get; protected set; }
        public virtual TypeOfDamage WeaponTypeOfDamage { get; }
        public virtual int ShieldBonusArmor { get; private set; }
        public virtual int ArmorOfArmor { get; set; }
        public virtual TypeOfWeapon WeaponType { get; set; }
        public abstract string Description { get; set; }
        public abstract TypeOfStuff TypeOfStuff { get; protected set; }
        public abstract int BonusStats { get; protected set; }
    }
}