using System.Globalization;

namespace LegendOfRico.Data;

public class Biomes
{
    public TypeOfBiome BiomeType { get; set; }
    public List<Monster> MonsterPool { get; set; }
    public string ImageUrl {  get; set; }
    public string FightUrl { get; set; }

    public Biomes(TypeOfBiome type, List<Monster> pool, string image, string fight)
    {
        BiomeType = type;
        MonsterPool = pool;
        ImageUrl = image;
        FightUrl = fight;
    }
}