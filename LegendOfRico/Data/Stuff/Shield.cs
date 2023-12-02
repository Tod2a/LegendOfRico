namespace LegendOfRico.Data;

public class Shield : Item
{
    public virtual int ShieldBonusArmor { get; private set; }

    public Shield(string shieldName, int shieldPrice, int shieldArmor)
    {
        ItemName = shieldName;
        Price = shieldPrice;
        ShieldBonusArmor = shieldArmor;
    }
}