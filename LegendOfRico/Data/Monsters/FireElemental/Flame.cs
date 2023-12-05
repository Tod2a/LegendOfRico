namespace LegendOfRico.Data
{
    public class Flame: FireElemental
    {
        public override string MonsterName { get; set; } = "Flamme";
        public override int MonsterHP { get; set; } = 100;
        public override int MonsterCurrentHP { get; set; } = 100;
        public override string fightImgUrl { get; set; } = "img/monster/fireelemental/flame.png";
        public override int XpGranted { get; set; } = 100;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Brulure", MinDamage = 9, MaxDamage = 14},
                new MonsterHit { Name = "Lance-Flamme", MinDamage = 15, MaxDamage = 25 }
            };

        }
    }
}
