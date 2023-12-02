namespace LegendOfRico.Data
{
    public class Bat : Beast
    {
        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; } 
        public override int MonsterMaxDamage { get; set; } 
        public override int MonsterHP { get; set; } 
        public override int MonsterCurrentHP { get; set; } 
        public override string fightImgUrl { get; set; }
        public override int XpGranted { get; set; }
        public int BiteMinDmg = 3;
        public int BiteMaxDmg = 6;
    }
}
