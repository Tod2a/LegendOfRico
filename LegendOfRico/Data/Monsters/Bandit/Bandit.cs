namespace LegendOfRico.Data
{
    public abstract class Bandit: Humanoid
    {
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bandit;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None };

        public Bandit()
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}
