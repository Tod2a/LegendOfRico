namespace LegendOfRico.Data;

public class Armor : Stuff
{
    public TypeOfArmor ArmorType { get; private set; }
    public int ArmorOfArmor { get; private set; }

    public Armor(string armorName, int armorPrice, TypeOfArmor armorType, int armorOfArmor)
    {
        ItemName = armorName;
        Price = armorPrice;
        ArmorType = armorType;
        ArmorOfArmor = armorOfArmor;
    }
}