namespace LegendOfRico.Data
{
    public class EternalScorpio: Boss
    {
        public override string MonsterName { get; set; } = "Le scorpion éternel";
        public override int MonsterCurrentHP { get; set; } = 5000;
        public override int MonsterHP { get; set; } = 5000;
        public override MonsterHit[] HitTable { get; set; } = new MonsterHit[] { };
        public override TypeOfBreed MonsterBreed { get; set; } = TypeOfBreed.EternalScorpio;
        public override int XpGranted { get; set; } = 2500;
        public override string fightImgUrl { get; set; } = "img/monster/Boss/Escorpio.png";

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
            {
                new MonsterHit{Name = "Aiguille d'Antarès", MinDamage = 100, MaxDamage = 200}
            };
        }
    }
}
