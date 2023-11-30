namespace LegendOfRico.Data
{
    public class Wizard : Character
    {
        public override TypeOfWeapon[] WeaponMastery => new[] { TypeOfWeapon.Staff };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Light;
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>() { new Fireball() };
        public override bool CanEquipShield { get; protected set; } = false;
        public override int MaxHitPoints => 20;
        public override string fightImgUrl { get; } = "img/Character/fightWizard.png";

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