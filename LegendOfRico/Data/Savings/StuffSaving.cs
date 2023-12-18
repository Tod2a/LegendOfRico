namespace LegendOfRico.Data
{
    public class StuffSaving
    {
        public string ItemName { get; set; }
        public bool IsEquip {  get; set; }

        public StuffSaving() { }

        public StuffSaving(Stuff stuff, bool equip)
        {
            ItemName = stuff.ItemName;
            IsEquip = equip;
        }

    }
}
