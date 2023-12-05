namespace LegendOfRico.Data
{
    public class QuestGiver: NPC
    {
        public override string NPCName { get; protected set; }
        public List<Quest> Quests {  get; private set; } 

        public QuestGiver(string nPCName)
        {
            NPCName = nPCName;
            Quests = new List<Quest>()
            {
                new Quest("Chasse un chien", "va dans les plaines et chasse un chien", TypeOfBreed.Dog, 10, 10) 
            };
        }

        public void AddQuest(string name, string description, TypeOfBreed target, int xpreward, int coinreward)
        {
            Quests.Add(new Quest(name, description, target,xpreward, coinreward));
        }

        public void RemoveQuest(Quest quest) 
        {
            Quests.Remove(quest);
        }

    }
}
