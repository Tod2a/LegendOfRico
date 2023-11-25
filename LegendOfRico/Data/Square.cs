namespace LegendOfRico.Data
{
    public class Square
    {
        public Biomes SquareBiome { get;  set; }
        public string Name { get; set; }
        public double ChanceToTriggerFight { get; set; }
        public bool HasNPC { get; set; } = false;
        public bool HasQuestTarget { get; set; } = false;
    }
}
