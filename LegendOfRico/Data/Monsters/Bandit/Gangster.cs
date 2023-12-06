﻿namespace LegendOfRico.Data
{
    public class Gangster: Bandit
    {
        public override string MonsterName { get; set; } = "Gangster";
        public override int MonsterHP { get; set; } = 100;
        public override int MonsterCurrentHP { get; set; } = 100;
        public override string fightImgUrl { get; set; } = "img/monster/bandit/gangster.png";
        public override int XpGranted { get; set; } = 100;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Coup de point américain", MinDamage = 9, MaxDamage = 14},
                new MonsterHit { Name ="Coup de couteau", MinDamage = 15, MaxDamage = 25 }
            };
        }
    }
}