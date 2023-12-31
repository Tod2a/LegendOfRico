﻿namespace LegendOfRico.Data
{
    public class EternalScorpio: Boss
    {
        public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Beast;
        public override string MonsterName { get; set; } = "Le scorpion éternel";
        public override int MonsterCurrentHP { get; set; } = 900;
        public override int MonsterHP { get; set; } = 900;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.EternalScorpio;
        public override int XpGranted { get; set; } = 1250;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/Escorpio.png";
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
                new MonsterHit{Name = "Aiguille d'Antarès", MinDamage = 80, MaxDamage = 100}
            };
        }
    }
}
