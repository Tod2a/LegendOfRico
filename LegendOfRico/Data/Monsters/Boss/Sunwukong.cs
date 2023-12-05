namespace LegendOfRico.Data
{
    public class Sunwukong: Boss
    {
        public override string MonsterName { get; set; } = "Le roi singe, Sun Wukong";
        public override int MonsterCurrentHP { get; set; } = 5000;
        public override int MonsterHP { get; set; } = 5000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Sunwukong;
        public override int XpGranted { get; set; } = 2500;
        public override string fightImgUrl { get; set; } = "";

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Baton magique", MinDamage = 100, MaxDamage = 200}
            };
        }
    }
}
