namespace LegendOfRico.Data
{
    public class LittleFlame: FireElemental
    {
        public override string MonsterName { get; set; } = "Petite Flamme";
        public override int MonsterHP { get; set; } = 50;
        public override int MonsterCurrentHP { get; set; } = 50;
        public override string fightImgUrl { get; set; } = "img/monster/fireelemental/littleflame.png";
        public override int XpGranted { get; set; } = 50;

        protected override MonsterHit[] BuildHitTable() 
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Flamméche", MinDamage = 5, MaxDamage = 10},
                new MonsterHit { Name = "Flamme", MinDamage = 7, MaxDamage = 12 }
            };
        }

    }
}
