namespace LegendOfRico.Data
{
    public class Rottweiler: StrayDog
    {
        public override string MonsterName { get; set; } = "Rottweiler";
        public override int MonsterHP { get; set; } = 500;
        public override int MonsterCurrentHP { get; set; } = 500;
        public override string fightImgUrl { get; set; } = "img/monster/spider/rottweiler.png";
        public override int XpGranted { get; set; } = 500;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Balafre", MinDamage = 5, MaxDamage = 8 },
                    new MonsterHit{Name = "éviscération", MinDamage = 25, MaxDamage = 30}
                };
        }
    }
}
