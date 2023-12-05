namespace LegendOfRico.Data
{
    public class BigSonOfAragog: Spider
    {
        public override string MonsterName { get; set; } = "L'ainé de Aragog";
        public override int MonsterHP { get; set; } = 250;
        public override int MonsterCurrentHP { get; set; } = 250;
        public override string fightImgUrl { get; set; } = "img/monster/spider/BigSonOfAragog.png";
        public override string PetImgUrl { get; set; } = "img/monster/Pet/BigSonOfAragog.png";
        public override int XpGranted { get; set; } = 100;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Déchirure", MinDamage = 15, MaxDamage = 20 },
                    new MonsterHit{Name = "Perforation", MinDamage = 10, MaxDamage = 15}
                };
        }
    }
}
