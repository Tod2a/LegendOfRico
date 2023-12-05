namespace LegendOfRico.Data
{
    public class Bulldog: StrayDog
    {
        public override string MonsterName { get; set; } = "Bulldog";
        public override int MonsterHP { get; set; } = 20;
        public override int MonsterCurrentHP { get; set; } = 20;
        public override string fightImgUrl { get; set; } = "img/monster/Dog/bulldog.png";
        public override string PetImgUrl { get; set; } = "img/monster/Pet/bulldog.png";
        public override int XpGranted { get; set; } = 50;

        protected override MonsterHit[] BuildHitTable()
        {
            return new MonsterHit[]
                {
                    new MonsterHit{Name = "Morsure", MinDamage = 5, MaxDamage = 7 }//,
                    //new MonsterHit{Name = "Piqure", MinDamage = 5, MaxDamage = 5}
                };
        }
    }
}
