namespace LegendOfRico.Data
{
    public abstract class Boss: Monster
    {
        public override TypeOfDamage[] MonsterWeakness { get; } = new TypeOfDamage[] { };
        public Boss()
        {
            HitTable = BuildHitTable();
        }
        protected abstract MonsterHit[] BuildHitTable();
        public Boolean IsSoothed { get; private set; }
        public int SoothDuration { get; private set; }

        public void Soothed()
        {
            IsSoothed = true;
            SoothDuration = 5;
        }

        public int DamageSoothed(int damageToSooth)
        {
            int postSoothDamage = damageToSooth;
            if (IsSoothed)
            {
                postSoothDamage /= 2;
                SoothDuration--;
                IsSoothed = (SoothDuration <= 0) ? false : true;
            }
            return postSoothDamage;
        }
    }
}
