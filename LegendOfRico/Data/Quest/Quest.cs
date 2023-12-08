namespace LegendOfRico.Data
{
    public abstract class Quest
    {
        public string QuestName { get; set; }
        public string Description { get; protected set; }
        public int XpReward { get; protected set; } 
        public int CoinsReward { get; protected set; } 
        public bool Status { get; set; } = false;
        public virtual TypeOfBreed Target { get; set; } = TypeOfBreed.Null;
        public Quest(string questName, string description, int xpreward, int coinreward)
        {
            QuestName = questName;
            Description = description;
            XpReward = xpreward;
            CoinsReward = coinreward;
        }

    }
}
