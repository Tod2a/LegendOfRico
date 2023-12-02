namespace LegendOfRico.Data
{
    public class Aragog: Spider
    {
        public override string MonsterName { get; set; } = "Aragog";
        public override int MonsterMinDamage { get; set; } = 5;
        public override int MonsterMaxDamage { get; set; } = 10;
        public override int MonsterHP { get; set; } = 500;
        public override int MonsterCurrentHP { get; set; } = 500;
        public override string fightImgUrl { get; set; } = "img/monster/spider/Aragog.png";
    }
}
