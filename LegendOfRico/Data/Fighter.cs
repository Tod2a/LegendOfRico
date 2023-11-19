namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public override TypeOfWeapon[] WeaponMastery { get; } = new[] { TypeOfWeapon.Axe, TypeOfWeapon.Sword };

        public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Heavy;
    }
}
