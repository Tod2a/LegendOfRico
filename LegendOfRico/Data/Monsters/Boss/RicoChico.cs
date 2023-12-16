namespace LegendOfRico.Data
{
    public class RicoChico: Boss
    {
        public override string MonsterName { get; set; } = "Le monstrueux RicoChico";
        public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Humanoid;
        public override int MonsterCurrentHP { get; set; } = 1500;
        public override int MonsterHP { get; set; } = 1500;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.RicoChico;
        public override int XpGranted { get; set; } = 100000;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/RicoChico.png";
        public override List<Stuff> LootTable { get; protected set; } = new List<Stuff>() {
            new Armor("Armure divine", "Armure : 45", 10000, TypeOfArmor.Light, 45),
        };

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Dance des hanches", MinDamage = 100, MaxDamage = 150}
            };
        }
    }
}
