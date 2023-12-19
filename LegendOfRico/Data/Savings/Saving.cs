using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LegendOfRico.Data
{
    public class Saving
    {
        public PlayerSaving PlayerSaving { get; set; }
        public List<StuffSaving> ItemList { get; set; } 
        public List<int> ConsumableQuantity { get; set; }
        public List<SavingQuest> QuestsInventory { get; set; }
        public List<SavingQuestGiver> QuestGivers { get; set; }

        public Saving() { }

        public Saving (Game game)
        {
            PlayerSaving = new PlayerSaving (game.Player);
            ItemList = SetItemList (game.Player);
            ConsumableQuantity = SetConsumalbeQuantity (game.Player);
            QuestsInventory = GetQuestBook(game.Player);
            QuestGivers = GetAllQuestGivers(game);
        }

        public void Connect(Game game)
        {
            game.Player = GetLoadCharacter();
            game.GameMap = new Data.Map();
            game.Player.Name = PlayerSaving.CharactName;
            while (game.Player.Level < PlayerSaving.CharactLevel)
            {
                game.Player.CurrentXp = game.Player.XpToLevel;
                game.LevelUp(game.Player);
            }
            game.Player.CurrentXp = PlayerSaving.CharactXp;
            game.Player.CurrentHitPoints = PlayerSaving.CharactHp;
            game.Player.SetCoins(PlayerSaving.CharactCoins - 10);
            game.Player.PositionI = PlayerSaving.PositionI;
            game.Player.PositionJ = PlayerSaving.PositionJ;
            game.Player.Joydead = PlayerSaving.JoyDead;
            game.Player.Wukongdead = PlayerSaving.WukongDead;
            game.Player.Tontatondead = PlayerSaving.TontaDead;
            game.Player.Scorpiodead = PlayerSaving.ScorpioDead;
            game.Player.RicoDead = PlayerSaving.RicoDead;
            if (PlayerSaving.MateName != null)
            {
                foreach (var mates in game.Tavernist.CharactersToRecruit)
                {
                    if (mates.Name == PlayerSaving.MateName)
                    {
                        game.Player.SetCoins(mates.RecruitingPrice);
                        game.Recrut(mates);
                    }
                }
                game.Player.PartyMember.CurrentHitPoints = PlayerSaving.MateHp;
            }
            if (game.Player.GetType() == typeof(Ranger))
            {
                game.Player.Pet = GetLoadPet();
            }
            GetLoadSutff(game);
            CheckBossVictory(game);
            LoadConsumableInventory(game);
            LoadQuestBook(game);
            LoadQuestGivers(game);
            game.GameMap.UpdateMapDisplay(game.Player);
        }

        private List<SavingQuestGiver> GetAllQuestGivers (Game game)
        {
            return new List<SavingQuestGiver>()
                {
                    new SavingQuestGiver(game.GameMap.MapLayout[250][250].MisterQuest, 250, 250),
                    new SavingQuestGiver(game.GameMap.MapLayout[196][249].MisterQuest, 196, 249)
                };
                
        }


        private List<SavingQuest> GetQuestBook (Character player)
        {
            List<SavingQuest> book = new List<SavingQuest> ();
            foreach (var quest in player.QuestsBook) 
            {
                if (quest.GetType() == typeof(CollectQuest))
                {
                    CollectQuest tempquest = (CollectQuest)quest;
                    book.Add(new SavingQuest(tempquest, tempquest.PositionI, tempquest.PositionJ, tempquest.LocalBiome));
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

        private Character GetLoadCharacter()
        {
            if (PlayerSaving.CharactType == "ranger")
            {
                return new Ranger() { MapSprite = "img/character/spriteRanger.png" };
            }
            else if (PlayerSaving.CharactType == "cleric")
            {
                return new Cleric() { MapSprite = "img/character/spriteCleric.png" };
            }
            else if (PlayerSaving.CharactType == "fighter")
            {
                return new Fighter() { MapSprite = "img/character/spriteFighter.png" };
            }
            else if (PlayerSaving.CharactType == "rogue")
            {
                return new Rogue() { MapSprite = "img/character/spriteRogue.png" };
            }
            else
            {
                return new Wizard() { MapSprite = "img/character/spriteWizard.png" };
            }
        }

        private Beast GetLoadPet()
        {
            switch (PlayerSaving.PetType)
            {
                case "rottweiler":
                    return new Rottweiler();
                case "americanstaff":
                    return new Americanstaff();
                case "nosaffraid":
                    return new Nosaffraid();
                case "nosptipti":
                    return new Nosptipti();
                case "nosalto":
                    return new Nosalto();
                case "emperorscorpio":
                    return new EmperorScorpio();
                case "littlescorpio":
                    return new LittleScorpio();
                case "rockscorpio":
                    return new RockScorpio();
                case "aragog":
                    return new Aragog();
                case "bigsonofaragog":
                    return new BigSonOfAragog();
                case "sonofaragog":
                    return new SonOfAragog();
                case "alphawolf":
                    return new AlphaWolf();
                case "betawolf":
                    return new BetaWolf();
                case "omegawolf":
                    return new OmegaWolf();
                default:
                    return new Bulldog();
            }
        }

        private void GetLoadSutff(Game game)
        {
            foreach (var item in ItemList)
            {
                if (item.ItemName == "Armure divine")
                {
                    if (item.IsEquip)
                    {
                        game.Player.EquipStuff(new Armor("Armure divine", "Armure : 45", 10000, TypeOfArmor.Light, 45));
                    }
                    else
                    {
                        game.Player.StuffInventory.Add(new Armor("Armure divine", "Armure : 45", 10000, TypeOfArmor.Light, 45));
                    }
                }
                else
                {
                    foreach (var merchantstuff in game.Merchant.StuffStock)
                    {
                        if (item.ItemName == merchantstuff.ItemName)
                        {
                            game.Player.StuffInventory.Add(merchantstuff);
                            if (item.IsEquip)
                            {
                                game.Player.EquipStuff(merchantstuff);
                            }
                        }
                    }
                }
            }
        }

        private void CheckBossVictory(Game game)
        {
            if (game.Player.Wukongdead)
            {
               game.GameMap.MapLayout[72][53].ChanceToTriggerFight = 0.0;
            }
            if (game.Player.Tontatondead)
            {
                game.GameMap.MapLayout[36][401].ChanceToTriggerFight = 0.0;
            }
            if (game.Player.Joydead)
            {
                game.GameMap.MapLayout[428][58].ChanceToTriggerFight = 0.0;
            }
            if (game.Player.Scorpiodead)
            {
                game.GameMap.MapLayout[499][499].ChanceToTriggerFight = 0.0;
            }
            if (game.Player.RicoDead)
            {
                game.GameMap.MapLayout[246][250].ChanceToTriggerFight = 0.0;
            }
        }

        private void LoadConsumableInventory(Game game)
        {
            int count = 0;
            foreach (var item in game.Player.ConsumableInventory)
            {
                item.Quantity = ConsumableQuantity[count];
                count++;
            }
        }

        private void LoadQuestBook(Game game)
        {
            List<Quest> book = new List<Quest>();
            foreach (var quest in QuestsInventory)
            {
                if (quest.Type == "collectquest")
                {
                    book.Add(new CollectQuest(quest.Name, quest.Description, quest.Xp, quest.Coins, quest.Posi, quest.Posj, quest.Biome, quest.Status));
                    game.GameMap.MapLayout[quest.Posi][quest.Posj].IsACollectDestination = true;
                }
                else
                {
                    book.Add(new FightQuest(quest.Name, quest.Description, quest.MonsterType, quest.Xp, quest.Coins, quest.Status));
                }
            }
            game.Player.QuestsBook = book;
        }

        private void LoadQuestGivers(Game game)
        {
            foreach (var giver in QuestGivers)
            {
                QuestGiver temp = new QuestGiver(giver.Name);
                foreach (var quest in giver.Quests)
                {
                    if (quest.Type == "collectquest")
                    {
                        temp.AddCollecQuest(quest.Name, quest.Description, quest.Xp, quest.Coins, quest.Posi, quest.Posj, quest.Biome);
                    }
                    else
                    {
                        temp.AddFightQuest(quest.Name, quest.Description, quest.MonsterType, quest.Xp, quest.Coins);
                    }
                }
                game.GameMap.MapLayout[giver.PosI][giver.PosJ].MisterQuest = temp;
            }
        }

    }
}
