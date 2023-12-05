namespace LegendOfRico.Data
{
    public class Nosalto: Bat
    {
        public override string MonsterName { get; set; } = "Nosalto";
        public override int MonsterHP { get; set; } = 250;
        public override int MonsterCurrentHP { get; set; } = 250;
        public override string fightImgUrl { get; set; } = "img/monster/Bat/Nosalto.png";
        public override int XpGranted { get; set; } = 100;

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

