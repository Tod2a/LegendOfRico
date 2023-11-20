namespace LegendOfRico.Data
{
    public class Square
    {
        public Biomes SquareBiome { get;  set; }
        public string Name { get; set; }
        public double ChanceToTriggerFight { get; set; }
        public bool HasNPC {  get; set; }
        public bool HasQuestTarget {  get; set; }
    }
}
