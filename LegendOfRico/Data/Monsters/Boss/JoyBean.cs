namespace LegendOfRico.Data
{
    public class JoyBean: Boss
    {
        public override string MonsterName { get; set; } = "Le grand Joy Bean";
        public override int MonsterCurrentHP { get; set; } = 5000;
        public override int MonsterHP { get; set; } = 5000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Joybean;
        public override int XpGranted { get; set; } = 2500;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/Joybean.png";
        public override List<Stuff> LootTable { get; protected set; } = new List<Stuff>() {
            new Axe("Hache en mithril", "(24 - 48) | Stats +8", 400, 24, 48, 8),
            new Bow("Arc en orme", "(40 - 64) | Stats +16", 400, 40, 64, 16),
            new Dagger("Dague en mithril", "(20 - 50) | Stats +8", 400, 20, 50, 8),
            new Greatsword("Espadon en mithril", "(40 - 64) | Stats +16", 400, 40, 64, 16),
            new Mace("Masse en mithril", "(16 - 40) | Stats +8", 400, 16, 40, 8),
            new Staff("Baton en orme", "(1 - 5) | Stats +16", 400, 1, 5, 16),
            new Sword("Epée en mithril", "(24 - 48) | Stats +8", 400, 24, 48, 8),
            new Armor("Armure en soie", "Léger | Armure : 16", 800, TypeOfArmor.Light, 16),
            new Armor("Armure en cuir travaillé", "Moyen | Armure : 22", 1000, TypeOfArmor.Medium, 22),
            new Armor("Armure en mithril", "Lourd | Armure : 30", 1200, TypeOfArmor.Heavy, 30)
        };

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Gomu rafale", MinDamage = 100, MaxDamage = 200}
            };
        }
    }
}
