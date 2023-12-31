﻿namespace LegendOfRico.Data
{
    public abstract class Bat : Beast
    {
        public override MonsterHit[] HitTable { get; set; }
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Bat;
        public override TypeOfDamage[] MonsterWeakness => new[] { TypeOfDamage.None };

        public Bat()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
