﻿namespace LegendOfRico.Data
{
    public class Cauchemar: Ghost
    {
        public override string MonsterName { get; set; } = "Cauchemar";
        public override int MonsterHP { get; set; } = 200;
        public override int MonsterCurrentHP { get; set; } = 200;
        public override string fightImgUrl { get; set; } = "img/monster/ghost/Cauchemar.png";
        public override int XpGranted { get; set; } = 200;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit {Name ="Crash Obscur", MinDamage = 26, MaxDamage = 35},
                new MonsterHit { Name ="Dévorêves", MinDamage = 36, MaxDamage = 45 }
            };
        }
    }
}
