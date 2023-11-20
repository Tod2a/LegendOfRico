namespace LegendOfRico.Data;

public class Rogue : Character
{
    public override TypeOfWeapon[] WeaponMastery { get; } = new[] {TypeOfWeapon.Dagger };
    public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Medium;
    public void Steal(Monster target)
    {
        // a defnir
    }

    
}