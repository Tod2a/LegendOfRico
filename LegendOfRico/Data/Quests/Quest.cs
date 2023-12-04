namespace LegendOfRico.Data
{
    public class Quest
    {
        public string QuestName { get; set; }
        public string Description { get; protected set; }
        public int XpReward { get; protected set; } = 0;
        public int CoinsReward { get; protected set; } = 0;

    }
}
