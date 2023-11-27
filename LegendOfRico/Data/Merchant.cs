namespace LegendOfRico.Data
{
    public class Merchant : NPC
    {
        public override string NPCName { get; protected set; } = "Marchand louche";
        public List<Item> ItemsStock { get; private set; }

        public Merchant()
        {
            //Low level gear
            ItemsStock.Add(new Axe("Hache en bronze", 50, 3, 6));
            ItemsStock.Add(new Bow("Arc en frêne", 50, 3, 6));
            ItemsStock.Add(new Dagger("Dague en bronze", 50, 2, 6));
            ItemsStock.Add(new Greatsword("Espadon en bronze", 50, 5, 8));
            ItemsStock.Add(new Mace("Masse en bronze", 50, 2, 5));
            ItemsStock.Add(new Staff("Baton en frêne", 50, 1, 5));
            ItemsStock.Add(new Sword("Epée en bronze", 50, 3, 6));

            //Mid level gear
            ItemsStock.Add(new Axe("Hache en fer", 50, 3, 6));
            ItemsStock.Add(new Bow("Arc en noyer", 50, 3, 6));
            ItemsStock.Add(new Dagger("Dague en fer", 50, 2, 6));
            ItemsStock.Add(new Greatsword("Espadon en fer", 50, 5, 8));
            ItemsStock.Add(new Mace("Masse en fer", 50, 2, 5));
            ItemsStock.Add(new Staff("Baton en noyer", 50, 1, 5));
            ItemsStock.Add(new Sword("Epée en fer", 50, 3, 6));

            //High level gear
            ItemsStock.Add(new Axe("Hache en acier", 50, 3, 6));
            ItemsStock.Add(new Bow("Arc en chêne", 50, 3, 6));
            ItemsStock.Add(new Dagger("Dague en acier", 50, 2, 6));
            ItemsStock.Add(new Greatsword("Espadon en acier", 50, 5, 8));
            ItemsStock.Add(new Mace("Masse en acier", 50, 2, 5));
            ItemsStock.Add(new Staff("Baton en chêne", 50, 1, 5));
            ItemsStock.Add(new Sword("Epée en acier", 50, 3, 6));

            //Endgame gear
            ItemsStock.Add(new Axe("Hache en mithril", 50, 3, 6));
            ItemsStock.Add(new Bow("Arc en orme", 50, 3, 6));
            ItemsStock.Add(new Dagger("Dague en mithril", 50, 2, 6));
            ItemsStock.Add(new Greatsword("Espadon en mithril", 50, 5, 8));
            ItemsStock.Add(new Mace("Masse en mithril", 50, 2, 5));
            ItemsStock.Add(new Staff("Baton en orme", 50, 1, 5));
            ItemsStock.Add(new Sword("Epée en mithril", 50, 3, 6));

            //Miscellaneous
            ItemsStock.Add(new Potion()); //Need to fix how Potion work
        }
    }
}
