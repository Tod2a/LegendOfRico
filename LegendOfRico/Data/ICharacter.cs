namespace LegendOfRico.Data;

public interface ICharacter
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int HitPoints { get; private set; }
    public Dictionary<Stats, int> Statistics { get; private set; }
    public int Armor { get; private set; }
}