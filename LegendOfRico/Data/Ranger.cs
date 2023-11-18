namespace LegendOfRico.Data;

public class Ranger : Character
{
    public Weapon[] WeaponMastery { get; private set; }
    public TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Medium;
}