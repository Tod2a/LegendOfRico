namespace LegendOfRico.Data
{
    public class QuestGiver: NPC
    {
        public override string NPCName { get; protected set; }
        public List<Quest> Quests {  get; private set; } 

        //Contructeur nécéssitant uniquement un nom
        public QuestGiver(string nPCName)
        {
            NPCName = nPCName;
            Quests = new List<Quest>()
            {
            };
        }

        //Fonction de création d'une quête de chasse se basant sur la race du monstre
        public void AddFightQuest(string name, string description, TypeOfBreed target, int xpreward, int coinreward)
        {
            Quests.Add(new FightQuest(name, description, target,xpreward, coinreward));
        }
        //Fonction de création des quêtes de collectes
        public void AddCollecQuest(string name, string description,  int xpreward, int coinreward, int posi, int posj, TypeOfBiome biome)
        {
            Quests.Add(new CollectQuest(name, description, xpreward, coinreward, posi, posj, biome));
        }

        //Fonction de suppression de la quête dans la liste des quêtes disponibles
        public void RemoveQuest(Quest quest) 
        {
            Quests.Remove(quest);
        }

    }
}
