namespace LegendOfRico.Data
{
    public class BurnHeal: Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;


        public BurnHeal(string name, string description, int price) : base(name,description, price) { }

        public override void Use(Character character)
        {
            base.Use(character);
            character.IsBurning = false;
            character.BurnDuration = 0;
        }

        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            character.IsBurning = false;
            character.BurnDuration = 0;
            return "Vous vous aspegez d'anti-brulure, cela vous soulage de vos maux ";
        }
    }
}
