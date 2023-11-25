namespace LegendOfRico.Data
{
    public abstract class Potion : Item
    {
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;

        public int RollHealValue(int value) // à définir
        {
            return (new Random()).Next(MinHeal, MaxHeal + 1);
        }
    }
}
