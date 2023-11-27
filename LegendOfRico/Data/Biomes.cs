namespace LegendOfRico.Data;

public class Biomes
{
    public TypeOfBiome BiomeType { get; set; }
    public Monster[] MonsterPool { get; set; }
    public string ImageUrl {  get; set; }
    public string FightUrl { get; set; }
}