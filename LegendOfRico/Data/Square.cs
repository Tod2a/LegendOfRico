namespace LegendOfRico.Data
{
    public class Square
    {
        public Biomes SquareBiome { get;  set; }
        public string Name { get; set; }
        public double ChanceToTriggerFight { get; set; }
        public bool HasNPC { get; set; } = false;
        public bool HasQuestTarget { get; set; } = false;
        public bool HasMonsterCollectQuest { get; set; } = false;
        public bool HasTargetCollectQuest { get; set; } = false;
        public QuestGiver MisterQuest {  get; set; } = new QuestGiver("Donneur de quête");
    }
}
