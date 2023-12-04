namespace LegendOfRico.Data
{
    public class Cheetah : Beast
    {
        public override string MonsterName { get; set; } 

        public override int MonsterHP { get; set; } 
        public override int MonsterCurrentHP { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bat;
        public override string fightImgUrl { get; set; }
        public override int XpGranted { get; set; }


        public double ChanceToDodge = 0.25;
    }
}
