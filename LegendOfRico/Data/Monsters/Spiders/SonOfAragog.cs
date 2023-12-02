namespace LegendOfRico.Data
{
    public class SonOfAragog: Spider
    {
        public override string MonsterName { get; set; } = "AragornJr"; 
        public override int MonsterMinDamage { get; set; } = 5;
        public override int MonsterMaxDamage { get; set; } = 10;
        public override int MonsterHP { get; set; } = 100;
        public override int MonsterCurrentHP { get; set; } = 100;
        public override string fightImgUrl { get; set; } = "img/monster/Spider/SonOfAragog.png";
        public override int XpGranted { get; set; } = 50;
    }
}
