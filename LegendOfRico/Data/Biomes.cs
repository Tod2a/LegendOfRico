using System.Globalization;

namespace LegendOfRico.Data;

public class Biomes
{
    public TypeOfBiome BiomeType { get; set; }
    public List<Type> MonsterPool { get; set; }
    public string ImageUrl {  get; set; }
    public string FightUrl { get; set; }

}