namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        public override TypeOfWeapon[] WeaponMastery { get; } = new[] { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Light;
        public Dictionary<Spells, int> SpellBook { get; private set; } //int-- à chaque utilisation du spell correspondant
        
        public void InitializeSpellBook()
        {
            Spells WizardFireball = new Fireball();
            SpellBook.Add(WizardFireball, WizardFireball.MaxNumberOfUses);
        }
    }
}
