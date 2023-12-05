namespace LegendOfRico.Data
{
    public class Spectre: Ghost
    {
        public override string MonsterName { get; set; } = "Spectre";
        public override int MonsterHP { get; set; } = 100;
        public override int MonsterCurrentHP { get; set; } = 100;
        public override string fightImgUrl { get; set; } = "img/monster/ghost/Spectre.png";
        public override int XpGranted { get; set; } = 100;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Ténèbre", MinDamage = 9, MaxDamage = 14},
                new MonsterHit { Name ="Tourmante", MinDamage = 15, MaxDamage = 25 }
            };
        }
    }
}
