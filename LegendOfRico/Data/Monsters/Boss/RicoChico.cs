namespace LegendOfRico.Data
{
    public class RicoChico: Boss
    {
        public override string MonsterName { get; set; } = "Le monstrueux RicoChico";
        public override int MonsterCurrentHP { get; set; } = 10000;
        public override int MonsterHP { get; set; } = 10000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.RicoChico;
        public override int XpGranted { get; set; } = 50000;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/RicoChico.png";

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Dance des hanches", MinDamage = 200, MaxDamage = 500}
            };
        }
    }
}
