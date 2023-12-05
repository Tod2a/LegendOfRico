namespace LegendOfRico.Data
{
    public class Quest
    {
        public string QuestName { get; set; }
        public string Description { get; protected set; }
        public int XpReward { get; protected set; } 
        public int CoinsReward { get; protected set; } 
        public TypeOfBreed Target { get; set; }
        public bool status { get; set; } = false;

        public Quest(string questName, string description, TypeOfBreed target, int xpreward, int coinreward)
        {
            QuestName = questName;
            Description = description;
            Target = target;
            XpReward = xpreward;
            CoinsReward = coinreward;
        }

    }
}
