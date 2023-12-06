namespace LegendOfRico.Data
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

            StuffStock.Add(new Axe("Hache en bronze", "(3 - 6)", 50, 3, 6, 0));
            StuffStock.Add(new Bow("Arc en frêne", "(5 - 8)", 50, 5, 8, 0));
            StuffStock.Add(new Dagger("Dague en bronze", "(2 - 6)", 50, 3, 6, 0));
            StuffStock.Add(new Greatsword("Espadon en bronze", "(5 - 8)", 50, 5, 8, 0));
            StuffStock.Add(new Mace("Masse en bronze", "(2 - 5)", 50, 2, 5, 0));
            StuffStock.Add(new Staff("Baton en frêne", "(1 - 5) | Stats +2", 50, 1, 5, 2));
            StuffStock.Add(new Sword("Epée en bronze", "(3 - 6)", 50, 3, 6, 0));
            StuffStock.Add(new Armor("Armure en jute", "Léger | Armure : 2", 50, TypeOfArmor.Light, 2));
            StuffStock.Add(new Armor("Armure en cuir brute", "Moyen | Armure : 3", 75, TypeOfArmor.Medium, 3));
            StuffStock.Add(new Armor("Armure en bronze", "Lourd | Armure : 4", 100, TypeOfArmor.Heavy, 4));
            StuffStock.Add(new Shield("Bouclier en bronze", "Amure : 5", 50, 5));

            //Mid level gear
            StuffStock.Add(new Axe("Hache en fer", "(6 - 12) | Stats +2", 100, 6, 12, 2));
            StuffStock.Add(new Bow("Arc en noyer", "(10 - 16) | Stats +4", 100, 10, 16, 4));
            StuffStock.Add(new Dagger("Dague en fer", "(4 - 12) | Stats +2", 100, 4, 12, 2));
            StuffStock.Add(new Greatsword("Espadon en fer", "(10 - 16) | Stats +4", 100, 10, 16, 4));
            StuffStock.Add(new Mace("Masse en fer", "(4 - 10) | Stats +2", 100, 4, 10, 2));
            StuffStock.Add(new Staff("Baton en noyer", "(1 - 5) | Stats +4", 100, 1, 5, 4));
            StuffStock.Add(new Sword("Epée en fer", "(6 - 12) | Stats +2", 100, 6, 12, 2));
            StuffStock.Add(new Armor("Armure en lin", "Léger | Armure : 4", 150, TypeOfArmor.Light, 4));
            StuffStock.Add(new Armor("Armure en cuir fin", "Moyen | Armure : 6", 200, TypeOfArmor.Medium, 6));
            StuffStock.Add(new Armor("Armure en fer", "Lourd | Armure : 8", 250, TypeOfArmor.Heavy, 8));
            StuffStock.Add(new Shield("Bouclier en fer", "Amure : 9", 100, 9));

            //High level gear
            StuffStock.Add(new Axe("Hache en acier", "(12 - 24) | Stats +4", 200, 12, 24, 4));
            StuffStock.Add(new Bow("Arc en chêne", "(20 - 32) | Stats +8", 200, 20, 32, 8));
            StuffStock.Add(new Dagger("Dague en acier", "(10 - 24) | Stats +4", 200, 10, 24, 4));
            StuffStock.Add(new Greatsword("Espadon en acier", "(20 - 32) | Stats +8", 200, 20, 32, 8));
            StuffStock.Add(new Mace("Masse en acier", "(8 - 20) | Stats +4", 200, 8, 20, 4));
            StuffStock.Add(new Staff("Baton en chêne", "(1 - 5) | Stats +8", 200, 1, 5, 8));
            StuffStock.Add(new Sword("Epée en acier", "(12 - 24) | Stats +4", 200, 12, 24, 4));
            StuffStock.Add(new Armor("Armure en coton", "Léger | Armure : 8", 450, TypeOfArmor.Light, 8));
            StuffStock.Add(new Armor("Armure en cuir épais", "Moyen | Armure : 12", 550, TypeOfArmor.Medium, 12));
            StuffStock.Add(new Armor("Armure en acier", "Lourd | Armure : 16", 650, TypeOfArmor.Heavy, 16));
            StuffStock.Add(new Shield("Bouclier en acier", "Amure : 18", 250, 18));

            //Endgame gear
            StuffStock.Add(new Axe("Hache en mithril", "(24 - 48) | Stats +8", 400, 24, 48, 8));
            StuffStock.Add(new Bow("Arc en orme", "(40 - 64) | Stats +16", 400, 40, 64, 16));
            StuffStock.Add(new Dagger("Dague en mithril", "(20 - 50) | Stats +8", 400, 20, 50, 8));
            StuffStock.Add(new Greatsword("Espadon en mithril", "(40 - 64) | Stats +16", 400, 40, 64, 16));
            StuffStock.Add(new Mace("Masse en mithril", "(16 - 40) | Stats +8", 400, 16, 40, 8));
            StuffStock.Add(new Staff("Baton en orme", "(1 - 5) | Stats +16", 400, 1, 5, 16));
            StuffStock.Add(new Sword("Epée en mithril", "(24 - 48) | Stats +8", 400, 24, 48, 8));
            StuffStock.Add(new Armor("Armure en soie", "Léger | Armure : 16", 800, TypeOfArmor.Light, 16));
            StuffStock.Add(new Armor("Armure en cuir travaillé", "Moyen | Armure : 22", 1000, TypeOfArmor.Medium, 22));
            StuffStock.Add(new Armor("Armure en mithril", "Lourd | Armure : 30", 1200, TypeOfArmor.Heavy, 30));
            StuffStock.Add(new Shield("Bouclier en mithril", "Amure : 35", 500, 35));


            //Miscellaneous
            ConsumableStock.Add(new Potion(1, "Petite potion de soin", 5, 1, 10));
            ConsumableStock.Add(new Potion(2, "Potion de soin", 10, 10, 20));
            ConsumableStock.Add(new Potion(3, "Grande potion de soin", 20, 20, 40));
            ConsumableStock.Add(new Potion(4, "Enorme potion de soin", 40, 40, 80));
        }
    }
}
