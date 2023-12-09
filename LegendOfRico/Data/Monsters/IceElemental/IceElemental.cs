namespace LegendOfRico.Data
{
    public abstract class IceElemental: Elemental
    {
        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.IceElemental;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Fire };

        public IceElemental()
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}
