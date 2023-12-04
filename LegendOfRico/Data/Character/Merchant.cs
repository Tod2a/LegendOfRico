﻿namespace LegendOfRico.Data
{
    public class Merchant : NPC
    {
        public override string NPCName { get; protected set; } = "Marchand louche";
        public List<Stuff> StuffStock { get; private set; }
        public List<Consumable> ConsumableStock { get; private set; }

        public Merchant()
        {
            StuffStock = new List<Stuff>();
            ConsumableStock = new List<Consumable>();
            //Low level gear
            StuffStock.Add(new Axe("Hache en bronze", 50, 3, 6));
            StuffStock.Add(new Bow("Arc en frêne", 50, 5, 8));
            StuffStock.Add(new Dagger("Dague en bronze", 50, 2, 6));
            StuffStock.Add(new Greatsword("Espadon en bronze", 50, 5, 8));
            StuffStock.Add(new Mace("Masse en bronze", 50, 2, 5));
            StuffStock.Add(new Staff("Baton en frêne", 50, 1, 5));
            StuffStock.Add(new Sword("Epée en bronze", 50, 3, 6));

            //Mid level gear
            StuffStock.Add(new Axe("Hache en fer", 100, 6, 12, 2));
            StuffStock.Add(new Bow("Arc en noyer", 100, 10, 16, 4));
            StuffStock.Add(new Dagger("Dague en fer", 100, 4, 12, 2));
            StuffStock.Add(new Greatsword("Espadon en fer", 100, 10, 16, 4));
            StuffStock.Add(new Mace("Masse en fer", 100, 4, 10, 2));
            StuffStock.Add(new Staff("Baton en noyer", 100, 1, 5, 4));
            StuffStock.Add(new Sword("Epée en fer", 100, 6, 12 , 2));

            //High level gear
            StuffStock.Add(new Axe("Hache en acier", 200, 12, 24, 4));
            StuffStock.Add(new Bow("Arc en chêne", 200, 20, 32, 8));
            StuffStock.Add(new Dagger("Dague en acier", 200, 8, 24, 4));
            StuffStock.Add(new Greatsword("Espadon en acier", 200, 20, 32, 8));
            StuffStock.Add(new Mace("Masse en acier", 200, 8, 20, 4));
            StuffStock.Add(new Staff("Baton en chêne", 200, 1, 5, 8));
            StuffStock.Add(new Sword("Epée en acier", 200, 12, 24, 4));

            //Endgame gear
            StuffStock.Add(new Axe("Hache en mithril", 400, 24, 48, 8));
            StuffStock.Add(new Bow("Arc en orme", 400, 40, 64, 16));
            StuffStock.Add(new Dagger("Dague en mithril", 400, 2, 6));
            StuffStock.Add(new Greatsword("Espadon en mithril", 400, 40, 64, 16));
            StuffStock.Add(new Mace("Masse en mithril", 400, 16, 40, 8));
            StuffStock.Add(new Staff("Baton en orme", 400, 1, 5, 16));
            StuffStock.Add(new Sword("Epée en mithril", 400, 24, 48, 8));

            //Miscellaneous
            ConsumableStock.Add(new Potion(1, "Petite potion de soin", 5, 1, 10));
            ConsumableStock.Add(new Potion(2, "Potion de soin", 10, 10, 20));
            ConsumableStock.Add(new Potion(3, "Grande potion de soin", 20, 20, 40));
            ConsumableStock.Add(new Potion(4, "Enorme potion de soin", 40, 40, 80));
        }
    }
}
