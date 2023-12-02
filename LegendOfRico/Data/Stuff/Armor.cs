namespace LegendOfRico.Data;

public class Armor : Item
{
    public TypeOfArmor ArmorType { get; private set; }
    public int ArmorOfArmor { get; private set; }

    public void SetArmorType(TypeOfArmor armorType)
    {
        ArmorType = armorType;
    }

    public void SetArmorOfArmor(int armorOfArmor)
    {
        ArmorOfArmor = armorOfArmor;
    }
}