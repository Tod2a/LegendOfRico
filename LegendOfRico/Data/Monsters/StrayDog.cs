namespace LegendOfRico.Data
{
    public class StrayDog : Beast
    {
        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; }
        public override int MonsterMaxDamage { get; set; } 
        public override int MonsterHP { get; set; }
        public override int MonsterCurrentHP { get; set; } 
        public override string fightImgUrl { get; set; }
        public override int XpGranted { get; set; }
        public int BiteMinDmg = 2;
        public int BiteMaxDmg = 6;

        public int ClawMinDmg = 3;
        public int ClawMaxDmg = 7;

        public double ChanceToDodge = 0.25;
    }
}
