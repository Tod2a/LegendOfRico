namespace LegendOfRico.Data
{
    public class Square
    {
        public Biomes SquareBiome { get;  set; }
        public string Name { get; set; }
        public double ChanceToTriggerFight { get; set; }
        // définition à false de base pour ne pas devoir déclarer à chaque square, il suffit de mettre à true lors de l'istance
        public bool HasNPC { get; set; } = false;
        public bool HasQuestTarget { get; set; } = false;
    }
}
