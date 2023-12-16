namespace LegendOfRico.Data
{
    public class EmperorScorpio: Scorpio
    {
        public override string MonsterName { get; set; } = "Scorpion Empereur";
        public override int MonsterHP { get; set; } = 320;
        public override int MonsterCurrentHP { get; set; } = 320;
        public override string fightImgUrl { get; set; } = "img/monster/Scorpio/emperorscorpio.png";
        public override int XpGranted { get; set; } = 230;
        public override int PetMinDamage { get; protected set; } = 25;
        public override int PetMaxDamage { get; protected set; } = 50;
        public override List<Stuff> LootTable { get; protected set; } = new List<Stuff>() {
            new Axe("Hache en acier", "(12 - 24) | Stats +4", 200, 12, 24, 4),
            new Bow("Arc en chêne", "(20 - 32) | Stats +8", 200, 20, 32, 8),
            new Dagger("Dague en acier", "(10 - 24) | Stats +4", 200, 10, 24, 4),
            new Greatsword("Espadon en acier", "(20 - 32) | Stats +8", 200, 20, 32, 8),
            new Mace("Masse en acier", "(8 - 20) | Stats +4", 200, 8, 20, 4),
            new Staff("Baton en chêne", "(1 - 5) | Stats +8", 200, 1, 5, 8),
            new Sword("Epée en acier", "(12 - 24) | Stats +4", 200, 12, 24, 4),
            new Armor("Armure en coton", "Léger | Armure : 8", 450, TypeOfArmor.Light, 8),
            new Armor("Armure en cuir épais", "Moyen | Armure : 12", 550, TypeOfArmor.Medium, 12),
            new Armor("Armure en acier", "Lourd | Armure : 16", 650, TypeOfArmor.Heavy, 16)
        };

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Balafre", MinDamage = 5, MaxDamage = 50 },
                    new MonsterHit{Name = "Eviscération", MinDamage = 25, MaxDamage = 30}
                };
        }
    }
}
