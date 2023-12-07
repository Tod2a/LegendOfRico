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
            };
        }

        public void AddFightQuest(string name, string description, TypeOfBreed target, int xpreward, int coinreward)
        {
            Quests.Add(new FightQuest(name, description, target,xpreward, coinreward));
        }
        public void AddCollecQuest(string name, string description,  int xpreward, int coinreward, int posi, int posj, TypeOfBiome biome)
        {
            Quests.Add(new CollectQuest(name, description, xpreward, coinreward, posi, posj, biome));
        }

        public void RemoveQuest(Quest quest) 
        {
            Quests.Remove(quest);
        }

    }
}
