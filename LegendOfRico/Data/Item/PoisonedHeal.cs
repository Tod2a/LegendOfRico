namespace LegendOfRico.Data
{
    public class PoisonedHeal : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedOnMate { get; protected set; } = true;

        //Récupération du constructeur de base des comsumble
        public PoisonedHeal(string name, string description, int price):base(name, description, price) { }

        //Définitaion de l'usage hors combat, permet de soigner du poison
        public override void Use(Character character)
        {
            base.Use(character);
            character.UnPoisoned();
        }

        //Définition de l'usage en combat avec le string à afficher sur l'interface, permet de soigner du poison
        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            character.UnPoisoned();
            return " se fait une injection d'anti-poison et pete la forme !";
        }
    }
}
