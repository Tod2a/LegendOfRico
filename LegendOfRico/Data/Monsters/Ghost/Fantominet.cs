namespace LegendOfRico.Data
{
    public class Fantominet: Ghost
    {
        public override string MonsterName { get; set; } = "Fantominet";
        public override int MonsterHP { get; set; } = 50;
        public override int MonsterCurrentHP { get; set; } = 50;
        public override string fightImgUrl { get; set; } = "img/monster/ghost/fantominet.png";
        public override int XpGranted { get; set; } = 50;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Boooo", MinDamage = 5, MaxDamage = 10},
                new MonsterHit { Name ="Rancunes", MinDamage = 7, MaxDamage = 12 }
            };
        }
    }
}
