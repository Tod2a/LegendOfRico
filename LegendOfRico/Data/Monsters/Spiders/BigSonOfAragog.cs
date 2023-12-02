namespace LegendOfRico.Data
{
    public class BigSonOfAragog: Spider
    {
        public override string MonsterName { get; set; } = "L'ainé de Aragog";
        public override int MonsterMinDamage { get; set; } = 5;
        public override int MonsterMaxDamage { get; set; } = 10;
        public override int MonsterHP { get; set; } = 250;
        public override int MonsterCurrentHP { get; set; } = 250;
        public override string fightImgUrl { get; set; } = "img/monster/basicSpider.png";
    }
}
