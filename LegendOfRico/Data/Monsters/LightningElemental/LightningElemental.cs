namespace LegendOfRico.Data
{
    public abstract class LightningElemental: Elemental
    {
        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.LightningElemental;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None};
        public override TypeOfDamage[] MonsterResistance => new[] { TypeOfDamage.Slashing, TypeOfDamage.Bludgeoning, TypeOfDamage.Piercing };

        public LightningElemental()
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}
 
