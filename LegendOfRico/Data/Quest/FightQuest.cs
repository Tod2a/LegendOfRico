namespace LegendOfRico.Data
{ 
    public class FightQuest: Quest
    {
        public override TypeOfBreed Target { get; set; }

        public FightQuest(string questName, string description, TypeOfBreed target, int xpreward, int coinreward )
            : base(questName, description, xpreward, coinreward)
        {
            Target = target;
        }
    }
}
