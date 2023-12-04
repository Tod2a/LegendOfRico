namespace LegendOfRico.Data
{
    public class MonsterQuest: Quest
    {
        public TypeOfMonster Target {  get; set; }

        public MonsterQuest(string questName, string description, TypeOfMonster target)
        {
            QuestName = questName;
            Description = description;
            Target = target;
        }

    }
}
