namespace LegendOfRico.Data
{
    public abstract class StrayDog : Beast
    {
        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Dog;

        //public double ChanceToDodge = 0.25;

        public StrayDog()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
