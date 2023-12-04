namespace LegendOfRico.Data;

public class Armor : Stuff
{
    public override string Description { get ; set ; }
    public override TypeOfStuff TypeOfStuff { get; protected set; } = TypeOfStuff.Armor;
    public TypeOfArmor ArmorType { get; private set; }
    public int ArmorOfArmor { get; private set; }

    public Armor(string armorName, string description, int armorPrice, TypeOfArmor armorType, int armorOfArmor)
    {
        ItemName = armorName;
        Description = description;
        Price = armorPrice;
        ArmorType = armorType;
        ArmorOfArmor = armorOfArmor;
    }
}