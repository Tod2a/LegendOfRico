namespace LegendOfRico.Data
{
    public class Wolf : Beast
    {
        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; } 
        public override int MonsterMaxDamage { get; set; }
        public override int MonsterHP { get; set; } 
        public override int MonsterCurrentHP { get; set; } 
        public override string fightImgUrl { get; set; } 
        public int BiteMinDmg = 5;
        public int BiteMaxDmg = 10;

        public int ClawMinDmg = 5;
        public int ClawMaxDmg = 10;

        public double ChanceToDodge = 0.25;
    }
}
