namespace LegendOfRico.Data
{
    public class Merchant : NPC
    {
        public override string NPCName { get; protected set; } = "Marchand louche";
        public List<Item> ItemsStock { get; private set; }

        public Merchant()
        {
            ItemsStock.Add(new Axe("Hache en bronze", 50, 3, 6));
            ItemsStock.Add(new Bow("Arc en frêne", 50, 3, 6));
            ItemsStock.Add(new Dagger("Dague en bronze", 50, 2, 6));
            ItemsStock.Add(new Greatsword("Espadon en bronze", 50, 5, 8));
            ItemsStock.Add(new Mace("Masse en bronze", 50, 2, 5));
            ItemsStock.Add(new Staff("Baton en frêne", 50, 1, 5));
            ItemsStock.Add(new Sword("Epée en bronze", 50, 3, 6));
        }
    }
}
