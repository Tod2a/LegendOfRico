namespace LegendOfRico.Data
{ 
    public class FightQuest: Quest
    {
        public override TypeOfBreed Target { get; set; }

        //Ajout de la cible dans le constructeur dans le cas d'une quête de chasse
        public FightQuest(string questName, string description, TypeOfBreed target, int xpreward, int coinreward )
            : base(questName, description, xpreward, coinreward)
        {
            Target = target;
        }
    }
}
