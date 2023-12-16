namespace LegendOfRico.Data
{
    public class PoisonedHeal : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedOnMate { get; protected set; } = true;
        
        public PoisonedHeal(string name, string description, int price):base(name, description, price) { }

        public override void Use(Character character)
        {
            base.Use(character);
            character.IsPoisoned = false;
            character.PoisonDamage = 1;
        }

        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            character.IsPoisoned = false;
            character.PoisonDamage = 1;

            return " se fait une injection d'anti-poison et pete la forme !";
        }
    }
}
