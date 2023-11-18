namespace LegendOfRico.Data
{
    public class Fighter: Character
    {
        public Weapon[] WeaponMastery {  get; private set; }

        public TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Heavy;
    }
}
