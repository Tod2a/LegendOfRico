namespace LegendOfRico.Data
{
    public class BurnHeal: Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedOnMate { get; protected set; } = true;

        //Récupération du constructeur de base des comsumble
        public BurnHeal(string name, string description, int price) : base(name,description, price) { }

        //Définitaion de l'usage hors combat, permet de soigner la brulure
        public override void Use(Character character)
        {
            base.Use(character);
            character.UnBurn();
        }

        //Définition de l'usage en combat avec le string à afficher sur l'interface, permet de soigner la brulure
        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            character.UnBurn();
            return character.Name + " s'asperge d'anti-brulure, cela le soulage de ses maux ";
        }
    }
}
