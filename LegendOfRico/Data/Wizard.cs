namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Light;
        public List<Spells> SpellBook { get; private set; } = new List<Spells>(); //int-- à chaque utilisation du spell correspondant
        public override bool CanEquipShield { get; protected set; } = false;
        public override int MaxHitPoints => 20;
        public override string fightImgUrl { get; } = "img/Character/fightWizard.png";

        public void InitializeSpellBook()
        {
            SpellBook.Add(new Fireball());
        }

        public override void Rest()
        {
            base.Rest();
            foreach(var spell in SpellBook)
            {
                spell.RefreshSpell();
            }
        }
    }
}