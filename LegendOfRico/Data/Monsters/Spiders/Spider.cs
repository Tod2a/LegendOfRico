namespace LegendOfRico.Data
{
    public class Spider : Beast {

        public override string MonsterName { get; set; } 
        public override int MonsterMinDamage { get; set; } 
        public override int MonsterMaxDamage { get; set; }
        public override int MonsterHP { get; set; }
        public override int MonsterCurrentHP { get; set; }
        public override string fightImgUrl { get; set; } 

        public int DoTMinDmg = 5;
        public int DoTMaxDmg = 10;

        public double ChanceToPoison = 0.75;

        public void Hit(Character target)
        {
            // a défnir 
        }
    }
}
