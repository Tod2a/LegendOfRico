namespace LegendOfRico.Data;

public class Shield : Stuff
{
    public virtual int ShieldBonusArmor { get; private set; }
    public override string Description { get ; set ; }

    public Shield(string shieldName, string description, int shieldPrice, int shieldArmor)
    {
        ItemName = shieldName;
        Description = description;
        Price = shieldPrice;
        ShieldBonusArmor = shieldArmor;
    }
}