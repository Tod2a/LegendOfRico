namespace LegendOfRico.Data;

public abstract class Item
{
    public string ItemName { get; protected set; }
    public string Description { get; protected set; }
    public int Price { get; protected set; }
}