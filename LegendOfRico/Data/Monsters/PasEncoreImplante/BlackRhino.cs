﻿namespace LegendOfRico.Data
{
    public class BlackRhino : Beast
    {
        public override string MonsterName { get; set; } 

        public override int MonsterHP { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bat;
        public override int MonsterCurrentHP { get; set; } 
        public override string fightImgUrl { get; set; }
        public override int XpGranted { get; set; }
        public int HitMinDmg = 5;
        public int HitMaxDmg = 10;
    }
}