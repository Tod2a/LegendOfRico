namespace LegendOfRico.Data
{
    public abstract class Ghost: Monster
    {
        public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Undead;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Ghost;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.Holy };
        public Ghost()
        {
            HitTable = BuildHitTable();
        }

        protected abstract MonsterHit[] BuildHitTable();
    }
}