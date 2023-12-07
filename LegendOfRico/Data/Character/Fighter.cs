namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override List<TypeOfWeapon> WeaponMastery =>
            new List<TypeOfWeapon> { TypeOfWeapon.Axe, TypeOfWeapon.Sword, TypeOfWeapon.Greatsword };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Heavy;
        public override Stuff CharacterWeapon { get; set; } = new Sword("Epée en bois","(2 - 3)", 5, 2, 3, 0);
        public override Stuff CharacterShield { get; set; } = new Shield("Bouclier en bois", "Armure : 3", 0, 3);
        public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
        public override bool CanEquipShield { get; set; } = true;
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Burst()};
        public override int MaxHitPoints { get; protected set; } = 30;
        public override int CurrentHitPoints { get; set; } = 30;
        public override int ArmorAmount { get; set; } = 4;
        public override double ChanceToDodge { get; protected set; } = 0.1;
        public override string fightImgUrl { get; } = "img/Character/fightFighter.png";
        public override int Statistics { get; set; } = 0;

        protected override void CheckLearnSpell()
        {
            int gainedHP = MaxHitPoints / 10 + Level;
            CurrentHitPoints += gainedHP;
            MaxHitPoints += gainedHP;
            Statistics += (5 + Level) / 2;

            if (Level == 3)
            {
                //Spell à défini
            }
        }
    }
}
