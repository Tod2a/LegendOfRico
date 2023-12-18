namespace LegendOfRico.Data
{
    public class StuffSaving
    {
        public string ItemType { get; set; }
        public Stuff Item { get; set; }
        public bool IsEquip {  get; set; }

        public StuffSaving() { }

        public StuffSaving(Stuff stuff, bool equip)
        {
            ItemType = GetStringType(stuff);
            Item = stuff;
            IsEquip = equip;
        }

        private string GetStringType(Stuff stuff)
        {
            if (stuff.GetType() == typeof(Armor))
            {
                return "armor";
            }
            else if (stuff.GetType() == typeof(Bow))
            {
                return "bow";
            }
            else if (stuff.GetType() == typeof(Dagger))
            {
                return "dagger";
            }
            else if (stuff.GetType() == typeof(Fist))
            {
                return "fist";
            }
            else if (stuff.GetType() == typeof(FistShield))
            {
                return "fistshield";
            }
            else if (stuff.GetType() == typeof(Greatsword))
            {
                return "greatsword";
            }
            else if (stuff.GetType() == typeof(Mace))
            {
                return "mace";
            }
            else if (stuff.GetType() == typeof(Shield))
            {
                return "shield";
            }
            else if (stuff.GetType() == typeof(Staff))
            {
                return "staff";
            }
            else if (stuff.GetType() == typeof(Sword))
            {
                return "sword";
            }
            else if (stuff.GetType() == typeof(Topless))
            {
                return "topless";
            }
            return "";
        }

    }
}
