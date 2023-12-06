namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Light;
        public override Stuff CharacterWeapon { get; set; } = new Staff("Baton en bois flotté", "(1 - 5) | Stats +1", 5, 1, 5, 1);
        public override Stuff CharacterShield { get; set; } = new FistShield("Poing", "Poing", 0, 0);
        public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Fireball() };
        public override bool CanEquipShield { get; set; } = false;
        public override int MaxHitPoints { get; protected set; } = 20;
        public override int CurrentHitPoints { get; set; } = 20;
        public override int ArmorAmount { get; set; } = 1;
        public override double ChanceToDodge { get; protected set; } = 0.05;
        public override string fightImgUrl { get; } = "img/Character/fightWizard.png";
        public override int Statistics { get; set; } = 1;

        protected override void CheckLearnSpell()
        {
            MaxHitPoints += MaxHitPoints / 10 + Level;
            Statistics += (5 + Level) / 2;
            if (Level == 3)
            {
                SpellBook.Add(new Incinerate());
            }
        }
    }
}