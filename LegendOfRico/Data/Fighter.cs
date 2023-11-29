namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override TypeOfWeapon[] WeaponMastery =>
            new[] { TypeOfWeapon.Axe, TypeOfWeapon.Sword, TypeOfWeapon.Greatsword };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Heavy;
        public override bool CanEquipShield { get; protected set; } = true;
        public override List<Spells> SpellBook { get; protected set; } = new List<Spells>();
        public override int MaxHitPoints => 30;
        public override string fightImgUrl { get; } = "img/Character/fightFighter.png";

        public void EquipGreatsword(Weapon greatsword)
        {
            EquipWeapon(greatsword);
            CanEquipShield = false;
        }

        public void UnequipGreatsword()
        {
            UnequipWeapon();
            CanEquipShield = true;
        }
    }
}
