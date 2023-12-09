namespace LegendOfRico.Data
{
    public class FlashOfLighting: LightningElemental
    {
        public override string MonsterName { get; set; } = "Éclair";
        public override int MonsterHP { get; set; } = 50;
        public override int MonsterCurrentHP { get; set; } = 50;
        public override string fightImgUrl { get; set; } = "img/monster/lightningelemental/flashoflighting.png";
        public override int XpGranted { get; set; } = 50;
        public override List<Stuff> LootTable { get; protected set; } = new List<Stuff>() {
            new Axe("Hache en bronze", "(3 - 6)", 50, 3, 6, 0),
            new Bow("Arc en frêne", "(5 - 8)", 50, 5, 8, 0),
            new Dagger("Dague en bronze", "(2 - 6)", 50, 2, 6, 0),
            new Greatsword("Espadon en bronze", "(5 - 8)", 50, 5, 8, 0),
            new Mace("Masse en bronze", "(2 - 5)", 50, 2, 5, 0),
            new Staff("Baton en frêne", "(1 - 5) | Stats +2", 50, 1, 5, 2),
            new Sword("Epée en bronze", "(3 - 6)", 50, 3, 6, 0),
            new Armor("Armure en jute", "Léger | Armure : 2", 50, TypeOfArmor.Light, 2),
            new Armor("Armure en bronze", "Lourd | Armure : 4", 100, TypeOfArmor.Heavy, 4),
            new Armor("Armure en cuir brute", "Moyen | Armure : 3", 75, TypeOfArmor.Medium, 3)
        };

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Éclair Fou", MinDamage = 5, MaxDamage = 10},
                new MonsterHit { Name = "Magnétisme", MinDamage = 7, MaxDamage = 12 } // Possibilité de paralysie ?
            };
        }
    }
}
