namespace LegendOfRico.Data
{
    public class Nosaffraid: Bat
    {
        public override string MonsterName { get; set; } = "Nosaffraid";
        public override int MonsterHP { get; set; } = 500;
        public override int MonsterCurrentHP { get; set; } = 500;
        public override string fightImgUrl { get; set; } = "img/monster/Spider/SonOfAragog.png";
        public override int XpGranted { get; set; } = 250;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Morsure", MinDamage = 10, MaxDamage = 15 },
                    new MonsterHit{Name = "Piqure", MinDamage = 5, MaxDamage = 10}
                };
        }
    }
}

