namespace LegendOfRico.Data
{
    public class JoyBean: Boss
    {
        public override string MonsterName { get; set; } = "Le grand Joy Bean";
        public override int MonsterCurrentHP { get; set; } = 5000;
        public override int MonsterHP { get; set; } = 5000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Joybean;
        public override int XpGranted { get; set; } = 2500;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/Joybean.png";

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Gomu rafale", MinDamage = 100, MaxDamage = 200}
            };
        }
    }
}
