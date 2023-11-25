namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override TypeOfWeapon[] WeaponMastery =>
            new[] { TypeOfWeapon.Axe, TypeOfWeapon.Sword, TypeOfWeapon.Greatsword };
        public override TypeOfArmor ArmorMastery => TypeOfArmor.Heavy;
        public override bool CanEquipShield { get; protected set; } = true;
        public override int MaxHitPoints => 30;

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
