namespace LegendOfRico.Data
{
    public class BreedQuest: Quest
    {
        public TypeOfBreed Target { get; set; }

        public BreedQuest(string questName, string description, TypeOfBreed target)
        {
            QuestName = questName;
            Description = description;
            Target = target;
        }

        public BreedQuest(string questName, string description, TypeOfBreed target, int xpreward)
        {
            QuestName = questName;
            Description = description;
            Target = target;
            XpReward = xpreward;
        }

        
    }
}
