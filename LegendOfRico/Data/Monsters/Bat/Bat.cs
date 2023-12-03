namespace LegendOfRico.Data
{
    public abstract class Bat : Beast
    {
        public override MonsterHit[] HitTable { get; set; }
   
        public Bat()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
