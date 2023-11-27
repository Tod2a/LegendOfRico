namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Light;
        public Dictionary<Spells, int> SpellBook { get; private set; } //int-- à chaque utilisation du spell correspondant
        public override bool CanEquipShield { get; protected set; } = false;
        public override int MaxHitPoints => 20;
        public override string fightImgUrl { get; } = "img/Character/fightWizard.png";

        public void InitializeSpellBook()
        {
            Spells WizardFireball = new Fireball();
            SpellBook.Add(WizardFireball, WizardFireball.MaxNumberOfUses);
        }
    }
}
