namespace LegendOfRico.Data
{
    public class QuestGiver: NPC
    {
        public override string NPCName { get; protected set; }
        public List<Quest> Quests {  get; set; } = new List<Quest>();

        public QuestGiver(string nPCName)
        {
            NPCName = nPCName;
        }

        public void AddMonsterQuest(string name, string description,  TypeOfMonster target)
        {
            Quests.Add(new MonsterQuest(name, description,target));
        }

        public void AddBreedQuest(string name, string description,  TypeOfBreed target)
        {
            Quests.Add(new BreedQuest(name, description, target));
        }
    }
}
