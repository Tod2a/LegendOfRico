namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        //Définition des Points de vie de base du sorcier
        public override int MaxHitPoints { get;  set; } = 20;
        public override int CurrentHitPoints { get; set; } = 20;
        //Définition du stuff de base du sorcier, ce qu'il peut porter, tout ce qui est utile au combat
        public override List<TypeOfWeapon> WeaponMastery => new List<TypeOfWeapon> { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Light;
        public override Stuff CharacterWeapon { get; set; } = new Staff("Baton en bois flotté", "(1 - 5) | Stats +1", 5, 1, 5, 1);
        public override Stuff CharacterShield { get; set; } = new FistShield("Poing", "Poing", 0, 0);
        public override Stuff CharacterArmor { get; set; } = new Armor("Haillons", "Des haillons", 5, TypeOfArmor.Light, 1);
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Fireball() };
        public override bool CanEquipShield { get; set; } = false;
        public override int ArmorAmount { get; set; } = 1;
        public override double ChanceToDodge { get; protected set; } = 0.05;
        public override string fightImgUrl { get; } = "img/Character/fightWizard.png";
        public override int Statistics { get; set; } = 1;

        // Utilisation de la fonction abstraite créée dans Character affin d'apprendre les sorts et faire gagner les stats
        protected override void CheckLearnSpell()
        {
            Spells frostArmor = new FrostArmor();

            int gainedHP = MaxHitPoints / 10 + Level;
            CurrentHitPoints += gainedHP;
            MaxHitPoints += gainedHP;
            Statistics += (5 + Level) / 2;

            if(Level == 2)
            {
                SpellBook.Add(new Frostbolt());
                SpellBook.Add(frostArmor);
            }
            if(Level == 3)
            {
                SpellBook.Add(new Incinerate());
            }
            if(Level == 4)
            {
                SpellBook.Add(new IceLance());
                SpellBook.Remove(SpellBook[2]);
                frostArmor = new FrostArmor2();
                SpellBook.Add(frostArmor);
            }
        }
    }
}