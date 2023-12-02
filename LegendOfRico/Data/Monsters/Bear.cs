﻿namespace LegendOfRico.Data
{
    public class Bear : Beast
    {
        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; }
        public override int MonsterMaxDamage { get; set; } 
        public override int MonsterHP { get; set; } 
        public override int MonsterCurrentHP { get; set; }
        public override string fightImgUrl { get; set; }
        public override int XpGranted { get; set; }
        public int ClawMinDmg = 5;
        public int ClawMaxDmg = 10;
    }
}
