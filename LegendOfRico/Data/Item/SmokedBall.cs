namespace LegendOfRico.Data
{
    public class SmokedBall : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = false;
        //Signalement que cet item permet de fuir un combat
        public override bool DodgeFight { get; protected set; } = true;

        //Récupération du constructeur
        public SmokedBall(string name,string description, int price) : base(name, description, price) { }

        //Définition de l'usage en combat retourne le string à afficher sur l'interface
        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);

            return "Vous fuyez le combat dans un nuage de fumée";
        }

    }
}
