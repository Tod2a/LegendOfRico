using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LegendOfRico.Data
{
    public class Saving
    {
        public PlayerSaving PlayerSaving { get; set; }
        public List<StuffSaving> ItemList { get; set; } 
        public List<int> ConsumableQuantity { get; set; }
        public List<SavingQuest> QuestsInventory { get; set; }

        public Saving() { }

        public Saving (Character player)
        {
            PlayerSaving = new PlayerSaving (player);
            ItemList = SetItemList (player);
            ConsumableQuantity = SetConsumalbeQuantity (player);
            QuestsInventory = GetQuestBook(player);
        }


        private List<SavingQuest> GetQuestBook (Character player)
        {
            List<SavingQuest> book = new List<SavingQuest> ();
            foreach (var quest in player.QuestsBook) 
            {
                if (quest.GetType() == typeof(CollectQuest))
                {
                    CollectQuest tempquest = (CollectQuest)quest;
                    book.Add(new SavingQuest(quest, tempquest.PositionI, tempquest.PositionJ, tempquest.LocalBiome));
                }
                else
                {
                    book.Add(new SavingQuest(quest));
                }
            }
            return book;
        }
        private List<int> SetConsumalbeQuantity(Character player)
        {
            List<int> result = new List<int>();
            foreach (var item in player.ConsumableInventory)
            {
                result.Add(item.Quantity);
            }
            return result;
        }
        private List<StuffSaving> SetItemList (Character player)
        {
            List<StuffSaving> itemlist = new List<StuffSaving>();
            if (player.CharacterWeapon.GetType() == typeof(DoubleWeapon))
            {
                DoubleWeapon doubleweapon = (DoubleWeapon)player.CharacterWeapon;
                if ( doubleweapon.Weapon1.ItemName != "Poing")
                {
                    itemlist.Add(new StuffSaving(doubleweapon.Weapon1, true));
                }
                if ( doubleweapon.Weapon2.ItemName != "Poing")
                {
                    itemlist.Add(new StuffSaving(doubleweapon.Weapon2, true));
                }
            }
            else
            {
                if ( player.CharacterWeapon.ItemName != "Poing")
                {
                    itemlist.Add(new StuffSaving(player.CharacterWeapon, true));
                }
            }
            if ( player.CharacterArmor.ItemName != "Rien")
            {
                itemlist.Add(new StuffSaving(player.CharacterArmor, true));
            }
            if ( player.CharacterShield.ItemName != "Poing")
            {
                itemlist.Add(new StuffSaving(player.CharacterShield, true));
            }
            foreach (var item in player.StuffInventory)
            {
                
                itemlist.Add(new StuffSaving(item, false));
             
            }
            return itemlist;
        }
        
    }
}
