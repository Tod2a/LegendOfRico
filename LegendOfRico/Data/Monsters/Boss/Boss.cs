namespace LegendOfRico.Data
{
    public abstract class Boss: Monster
    {
        public override TypeOfMonster MonsterType { get; set; } = TypeOfMonster.Boss;
        public override TypeOfDamage[] MonsterWeakness { get; } = new TypeOfDamage[] { };
        public Boss()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
