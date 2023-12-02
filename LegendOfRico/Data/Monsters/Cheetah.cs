namespace LegendOfRico.Data
{
    public class Cheetah : Beast
    {
        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; } 
        public override int MonsterMaxDamage { get; set; } 
        public override int MonsterHP { get; set; } 
        public override int MonsterCurrentHP { get; set; } 
        public override string fightImgUrl { get; set; } 
        

        public double ChanceToDodge = 0.25;
    }
}
