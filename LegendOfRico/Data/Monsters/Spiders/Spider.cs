﻿
namespace LegendOfRico.Data
{
    public abstract class Spider : Beast {

        public override MonsterHit[] HitTable { get; set; }
        public double ChanceToPoison = 0.75;

        public Spider()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
      
    }
}
