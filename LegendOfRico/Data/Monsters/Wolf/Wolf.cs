﻿namespace LegendOfRico.Data
{
    public abstract class Wolf : Beast
    {
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Wolf;

        public Wolf()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
    }
}
