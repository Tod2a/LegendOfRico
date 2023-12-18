namespace LegendOfRico.Data
{
    public class Saving
    {
        public PlayerSaving PlayerSaving { get; set; }
        //public List<StuffSaving> ItemList { get; set; } 

        public Saving() { }

        public Saving (Character player)
        {
            PlayerSaving = new PlayerSaving (player);
            //ItemList = SetItemList (player);
        }

        private List<StuffSaving> SetItemList (Character player)
        {
            List<StuffSaving> itemlist = new List<StuffSaving>();
            itemlist.Add(new StuffSaving(player.CharacterWeapon, true));
            itemlist.Add(new StuffSaving(player.CharacterArmor, true));
            itemlist.Add(new StuffSaving(player.CharacterShield, true));
            foreach (var item in player.StuffInventory)
            {
                itemlist.Add(new StuffSaving(item, false));
            }
            return itemlist;
        }
        
    }
}
