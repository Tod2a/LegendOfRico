namespace LegendOfRico.Data
{
    public abstract class Stuff: Item
    {
        public abstract string Description { get; set; }
        public abstract TypeOfStuff TypeOfStuff { get; protected set; }
    }
}
