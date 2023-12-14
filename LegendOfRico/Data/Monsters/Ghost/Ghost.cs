namespace LegendOfRico.Data
{
    public abstract class Ghost: Undead
    {
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Ghost;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy };
        public override TypeOfDamage[] MonsterResistance => new[] { TypeOfDamage.Slashing, TypeOfDamage.Bludgeoning, TypeOfDamage.Piercing };
        public Ghost()
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}