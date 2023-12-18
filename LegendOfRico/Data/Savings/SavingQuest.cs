namespace LegendOfRico.Data
{
    public class SavingQuest
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Xp {  get; set; } 
        public int Coins {  get; set; }
        public bool Status { get; set; }
        public TypeOfBreed MonsterType { get; set; }
        public int Posi { get; set; }
        public int Posj { get; set; }
        public TypeOfBiome Biome {  get; set; }


        public SavingQuest() { }

        public SavingQuest(Quest quest) 
        {
            Type = GetQuestType(quest);
            Name = quest.QuestName;
            Description = quest.Description;
            Xp = quest.XpReward;
            Coins = quest.CoinsReward;
            Status = quest.Status;
            MonsterType = quest.Target;
        }

        public SavingQuest(Quest quest, int posi, int posj, TypeOfBiome biome)
        {
            Type = GetQuestType(quest);
            Name = quest.QuestName;
            Xp = quest.XpReward;
            Coins = quest.CoinsReward;
            Status = quest.Status;
            MonsterType = quest.Target;
            Posi = posi;
            Posj = posj;
            Biome = biome;
        }

        private string GetQuestType(Quest quest) 
        {
            if (quest.GetType() == typeof(CollectQuest))
            {
                return "collectquest";
            }
            else
            {
                return "fightquest";
            }
        }
    }
}
