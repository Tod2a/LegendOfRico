namespace LegendOfRico.Data
{
    public class SavingQuestGiver
    {
        public string Name { get; set; }
        public int PosI { get; set; }
        public int PosJ { get; set; }
        public List<SavingQuest> Quests { get; set; }

        public SavingQuestGiver() { }

        public SavingQuestGiver(QuestGiver questgiver, int posi, int posj) 
        {
            Name = questgiver.NPCName;
            PosI = posi;
            PosJ = posj;
            Quests = GetQuestBook(questgiver);
        }

        private List<SavingQuest> GetQuestBook(QuestGiver questgiver)
        {
            List<SavingQuest> book = new List<SavingQuest>();
            foreach (var quest in questgiver.Quests)
            {
                if (quest.GetType() == typeof(CollectQuest))
                {
                    CollectQuest tempquest = (CollectQuest)quest;
                    book.Add(new SavingQuest(tempquest, tempquest.PositionI, tempquest.PositionJ, tempquest.LocalBiome));
                }
                else
                {
                    book.Add(new SavingQuest(quest));
                }
            }
            return book;
        }
    }
}
