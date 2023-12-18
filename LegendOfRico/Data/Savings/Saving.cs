using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LegendOfRico.Data
{
    public class Saving
    {
        public PlayerSaving PlayerSaving { get; set; }
        public List<StuffSaving> ItemList { get; set; } 

        public Saving() { }

        public Saving (Character player)
        {
            PlayerSaving = new PlayerSaving (player);
            ItemList = SetItemList (player);
        }

        private List<StuffSaving> SetItemList (Character player)
        {
            List<StuffSaving> itemlist = new List<StuffSaving>();
            if (player.CharacterWeapon.ItemName != "Epée en bois" && player.CharacterWeapon.ItemName != "Masse en bois" 
                && player.CharacterWeapon.ItemName != "Baton en bois flotté" && player.CharacterWeapon.ItemName !=  "Dague en bois" 
                && player.CharacterWeapon.ItemName != "Arc en bois flotté" && player.CharacterWeapon.ItemName != "Poing")
            {
                itemlist.Add(new StuffSaving(player.CharacterWeapon, true));
            }
            if (player.CharacterArmor.ItemName != "Haillons" && player.CharacterArmor.ItemName != "Rien")
            {
                itemlist.Add(new StuffSaving(player.CharacterArmor, true));
            }
            if (player.CharacterShield.ItemName != "Bouclier en bois" && player.CharacterShield.ItemName != "Poing")
            {
                itemlist.Add(new StuffSaving(player.CharacterShield, true));
            }
            foreach (var item in player.StuffInventory)
            {
                if (item.ItemName != "Epée en bois" && item.ItemName != "Masse en bois" && item.ItemName != "Baton en bois flotté"
                    && item.ItemName != "Dague en bois" && item.ItemName != "Arc en bois flotté" && item.ItemName != "Haillons" && item.ItemName != "Bouclier en bois")
                {
                    itemlist.Add(new StuffSaving(item, false));
                }
            }
            return itemlist;
        }
        
    }
}
