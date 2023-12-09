namespace LegendOfRico.Data
{
    public abstract class Scorpio: Beast
    {
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Scorpio;

        public Scorpio()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
