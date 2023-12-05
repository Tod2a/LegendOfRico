namespace LegendOfRico.Data
{
    public class Cheftontaton: Boss
    {
        public override string MonsterName { get; set; } = "Le grand chef des Tontaton";
        public override int MonsterCurrentHP { get; set; } = 5000;
        public override int MonsterHP { get; set; } = 5000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.Cheftontaton;
        public override int XpGranted { get; set; } = 2500;
        public override string fightImgUrl { get; set; } = "";

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Assaut multiple", MinDamage = 100, MaxDamage = 200}
            };
        }
    }
}
