namespace LegendOfRico.Data
{
    public class SonOfAragog: Spider
    {
        public override string MonsterName { get; set; } = "AragogJr"; 
        public override int MonsterHP { get; set; } = 100;
        public override int MonsterCurrentHP { get; set; } = 100;
        public override string fightImgUrl { get; set; } = "img/monster/Spider/SonOfAragog.png";
        public override string PetImgUrl { get; set; } = "img/monster/Pet/SonOfAragog.png";
        public override int XpGranted { get; set; } = 50;

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
