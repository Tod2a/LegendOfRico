namespace LegendOfRico.Data;

public abstract class Beast : Monster
{
    public Boolean isSoothed { get; private set; }

    public void Soothed()
    {
        isSoothed = true;
    }
}