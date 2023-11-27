namespace LegendOfRico.Data
{
    public class Potion : Item
    {
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;

        public Potion(string potionName, int potionPrice, int minHeal, int maxHeal)
        {
            ItemName = potionName;
            Price = potionPrice;
            MinHeal = minHeal;
            MaxHeal = maxHeal;
        }

        public int RollHealValue(int value) // à définir
        {
            return (new Random()).Next(MinHeal, MaxHeal + 1);
        }
    }
}
