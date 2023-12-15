namespace LegendOfRico.Data
{
    public class SmokedBall : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = false;
        public override bool DodgeFight { get; protected set; } = true;

        public SmokedBall(string name,string description, int price) : base(name, description, price) { }
        

        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);

            return "Vous fuyez le combat dans un nuage de fumée";
        }

    }
}
