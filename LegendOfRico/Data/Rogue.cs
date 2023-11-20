namespace LegendOfRico.Data;

public class Rogue : Character
{
    public override TypeOfWeapon[] WeaponMastery { get; } = new[] {TypeOfWeapon.Dagger };
    public override TypeOfArmor ArmorMastery { get; } = TypeOfArmor.Medium;
    public void Steal(Monster target)
    {
       if (target.MonsterType == TypeOfMonster.Humanoid)
        {
            Random chance = new Random();
            int a = chance.Next(1,10);

            if (a <= 6 )
            {
                // vole reussi
            }
            else
            {
                // vole raté
            }
        }
    }

    
}