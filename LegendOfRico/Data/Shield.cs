namespace LegendOfRico.Data;

public class Shield : Item
{
    public virtual int ShieldBonusArmor { get; private set; }

    public void set(int shieldArmor)
    {
        ShieldBonusArmor = shieldArmor;
    }
}