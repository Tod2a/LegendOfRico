namespace LegendOfRico.Data
{
    public class Nosalto: Bat
    {
        public override string MonsterName { get; set; } = "Nosalto";
        public override int MonsterHP { get; set; } = 80;
        public override int MonsterCurrentHP { get; set; } = 80;
        public override string fightImgUrl { get; set; } = "img/monster/Bat/Nosalto.png";
        public override int XpGranted { get; set; } = 120;
        public override int PetMinDamage { get; protected set; } = 15;
        public override int PetMaxDamage { get; protected set; } = 25;
        public override List<Stuff> LootTable { get; protected set; } = new List<Stuff>() {
            new Axe("Hache en fer", "(6 - 12) | Stats +2", 100, 6, 12, 2),
            new Bow("Arc en noyer", "(10 - 16) | Stats +4", 100, 10, 16, 4),
            new Dagger("Dague en fer", "(4 - 12) | Stats +2", 100, 4, 12, 2),
            new Greatsword("Espadon en fer", "(10 - 16) | Stats +4", 100, 10, 16, 4),
            new Mace("Masse en fer", "(4 - 10) | Stats +2", 100, 4, 10, 2),
            new Staff("Baton en noyer", "(1 - 5) | Stats +4", 100, 1, 5, 4),
            new Sword("Epée en fer", "(6 - 12) | Stats +2", 100, 6, 12, 2),
            new Armor("Armure en lin", "Léger | Armure : 4", 150, TypeOfArmor.Light, 4),
            new Armor("Armure en cuir fin", "Moyen | Armure : 6", 200, TypeOfArmor.Medium, 6),
            new Armor("Armure en fer", "Lourd | Armure : 8", 250, TypeOfArmor.Heavy, 8)
        };

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Balafre", MinDamage = 5, MaxDamage = 8 },
                    new MonsterHit{Name = "éviscération", MinDamage = 25, MaxDamage = 30}
                };
        }
    }
}

