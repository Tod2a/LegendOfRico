
namespace LegendOfRico.Data
{
    public abstract class Spider : Beast {

        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Spider;
        public double ChanceToPoison = 0.75;

        public Spider()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
      
    }
}
