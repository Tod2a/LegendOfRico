namespace LegendOfRico.Data
{
    public abstract class Potion : Item
    {
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;

        public void RollHealValue(int value) // à définir
        {

        }
    }
}
