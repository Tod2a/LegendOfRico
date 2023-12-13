namespace LegendOfRico.Data
{
    public class MonsterHit
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public double chanceToBurn { get; set; } = 0;
        public bool IsGroupHit { get; set; } = false;
    }
}
