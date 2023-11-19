namespace LegendOfRico.Data;

public class Ranger : Character
{
    public override TypeOfWeapon[] WeaponMastery { get; } = new[] { TypeOfWeapon.Sword, TypeOfWeapon.Bow };
    public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Medium;

    public void Sooth(Beast target){
        target.Soothed();
    }
}