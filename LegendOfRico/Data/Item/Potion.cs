namespace LegendOfRico.Data
{
    public class Potion : Item
    {
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;
        public int Quantity { get; set; }


        public Potion(string potionName, int potionPrice, int minHeal, int maxHeal)
        {
            ItemName = potionName;
            Price = potionPrice;
            MinHeal = minHeal;
            MaxHeal = maxHeal;
        }

        public Potion(string potionName, int potionPrice, int minHeal, int maxHeal, int quantity)
        {
            ItemName = potionName;
            Price = potionPrice;
            MinHeal = minHeal;
            MaxHeal = maxHeal;
            Quantity = quantity;
        }

        public int RollHealValue(int value) // à définir
        {
            return (new Random()).Next(MinHeal, MaxHeal + 1);
        }
    }
}
