namespace LegendOfRico.Data;

public class Armor : Stuff
{
    public override string Description { get ; set ; }
    public override TypeOfStuff TypeOfStuff { get; protected set; } = TypeOfStuff.Armor;
    public TypeOfArmor ArmorType { get; private set; }
    public override int ArmorOfArmor { get; set; }
    public override int BonusStats { get; protected set; }

    public Armor(string armorName, string description, int armorPrice, TypeOfArmor armorType, int armorOfArmor)
    {
        ItemName = armorName;
        Description = description;
        Price = armorPrice;
        ArmorType = armorType;
        ArmorOfArmor = armorOfArmor;
    }
}