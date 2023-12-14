namespace LegendOfRico.Data
{
    public abstract class FireElemental: Elemental
    {
        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.FireElemental;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Cold };
        public override TypeOfDamage[] MonsterResistance => new[] { TypeOfDamage.Fire };
        public FireElemental() 
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}
