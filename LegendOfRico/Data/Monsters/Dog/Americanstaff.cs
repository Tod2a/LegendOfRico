﻿namespace LegendOfRico.Data
{ 
    public class Americanstaff: StrayDog
    {
        public override string MonsterName { get; set; } = "American Staff";
        public override int MonsterHP { get; set; } = 250;
        public override int MonsterCurrentHP { get; set; } = 250;
        public override string fightImgUrl { get; set; } = "img/monster/spider/americanstaff.png";
        public override int XpGranted { get; set; } = 100;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Déchirure", MinDamage = 15, MaxDamage = 20 },
                    new MonsterHit{Name = "Perforation", MinDamage = 10, MaxDamage = 15}
                };
        }


    }
}