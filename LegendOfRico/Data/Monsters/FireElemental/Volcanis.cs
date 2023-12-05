namespace LegendOfRico.Data
{
    public class Volcanis : FireElemental
    {
        public override string MonsterName { get; set; } = "Volcanis";
        public override int MonsterHP { get; set; } = 200;
        public override int MonsterCurrentHP { get; set; } = 200;
        public override string fightImgUrl { get; set; } = "img/monster/fireelemental/volcanis.png";
        public override int XpGranted { get; set; } = 200;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Surchauffe", MinDamage = 26, MaxDamage = 35},
                new MonsterHit { Name = "Déflagration", MinDamage = 36, MaxDamage = 45 }
            };

        }
    }
}