namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override List<TypeOfWeapon> WeaponMastery =>
            new List<TypeOfWeapon> { TypeOfWeapon.Axe, TypeOfWeapon.Sword, TypeOfWeapon.Greatsword };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Heavy;
        public override Stuff CharacterWeapon { get; protected set; } = new Sword("Epée en bois","une épée", 5, 2, 3, 0);
        public override Stuff CharacterShield { get; protected set; } = new Shield("Bouclier en bois", "Bouclier", 0, 3);
        public override Stuff CharacterArmor { get; protected set; } = new Armor("Haillons", "Haillons", 5, TypeOfArmor.Light, 1);
        public override bool CanEquipShield { get; protected set; } = true;
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Burst()};
        public override int MaxHitPoints => 30;
        public override int CurrentHitPoints { get; set; } = 30;
        public override int ArmorAmount { get; protected set; } = 4;
        public override double ChanceToDodge { get; protected set; } = 0.1;
        public override string fightImgUrl { get; } = "img/Character/fightFighter.png";

        protected override void CheckLearnSpell()
        {
            if (Level == 3)
            {
                //Spell à défini
            }
        }
        public void EquipGreatsword(Stuff greatsword)
        {
            EquipStuff(greatsword);
            CanEquipShield = false;
        }

        public void UnequipGreatsword()
        {
            UnequipWeapon();
            CanEquipShield = true;
        }
    }
}
