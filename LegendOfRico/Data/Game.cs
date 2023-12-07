using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace LegendOfRico.Data
{
    //Class "main" qui va permettre de développer les interactions entre le Player et la map tel que les combats, les savings etc
    public class Game
    {
        public Map GameMap { get; set; } = new Map();
        public Character Player { get; set; } = new Wizard { };
        public Character Player2 { get; set; } = new Cleric
        {
            Name = "Patrick (Clerc)"
        };
        public Monster MonsterFight { get; private set; } = new Bulldog { };
        public Merchant Merchant { get; private set; } = new Merchant();
        public TavernRecruits Tavernist { get; private set; } = new TavernRecruits();
        public bool IsCurrentFight { get; set; } = false;
        public string FightMessage { get; set; } = "";
        public bool PlayerDead = false;
        public bool MonsterDead = false;
        //série de paramètres/variables qui vont gérer l'affichage des différents display du jeu
        //gestion du menu de droite
        public bool ShowInventory = true;
        public bool ShowQuestList = false;
        public bool ShowQuestGiver = false;
        //gestion de l'interface de combat
        public bool ShowFightSpells = true;
        public bool ShowFightInventory = false;
        public int Turncount = 0;
        public TypeOfShow FormShow { get; set; } = TypeOfShow.Connection;

        public void LevelUp(Character player)
        {
            if (player.Equals(Player))
            {
                GameMap.MapLevel++;
            }
            player.Level++;
            FightMessage += player.Name + " gagne un niveau ! ";
            player.CurrentXp -= player.XpToLevel;
            player.XpToLevel += 250 * player.Level;
        }


        public void CreateCharacter(string CName, TypeOfCharacter Type)
        {
            if (Type == TypeOfCharacter.Magicien)
            {
                Player = new Wizard { Name = CName, MapSprite = "img/character/spriteWizard.png" };
            }
            else if (Type == TypeOfCharacter.Guerrier)
            {
                Player = new Fighter { Name = CName, MapSprite = "img/character/spriteFighter.png" };
            }
            else if (Type == TypeOfCharacter.Voleur)
            {
                Player = new Rogue { Name = CName, MapSprite = "img/character/spriteRogue.png" };
            }
            else if (Type == TypeOfCharacter.Clerc)
            {
                Player = new Cleric { Name = CName, MapSprite = "img/character/spriteCleric.png" };
            }
            else
            {
                Player = new Ranger { Name = CName, MapSprite = "img/character/spriteRanger.png" };
            }
            FormShow = TypeOfShow.Map;

        }

        public void Deconnection()
        {
            FormShow = TypeOfShow.Connection;
        }

        //gestion des quetes

        public void ValidQuest(Quest quest)
        {
            if (quest.GetType() == typeof(CollectQuest))
            {
                CollectQuest collecquest = (CollectQuest)quest;
                GameMap.MapLayout[collecquest.PositionI][collecquest.PositionJ].IsACollectDestination = false;
            }
            if (quest.Target == TypeOfBreed.Joybean)
            {
                Player.Joydead = true;
                GameMap.MapLayout[428][58].ChanceToTriggerFight = 0.0;
            }
            else if (quest.Target == TypeOfBreed.EternalScorpio)
            {
                Player.Scorpiodead = true;
                GameMap.MapLayout[499][499].ChanceToTriggerFight = 0.0;
            }
            else if (quest.Target == TypeOfBreed.Cheftontaton)
            {
                Player.Tontatondead = true;
                GameMap.MapLayout[36][401].ChanceToTriggerFight = 0.0;
            }
            else if (quest.Target == TypeOfBreed.Sunwukong)
            {
                Player.Wukongdead = true;
                GameMap.MapLayout[72][53].ChanceToTriggerFight = 0.0;
            }

            Player.LootGold(quest.CoinsReward);
            Player.CurrentXp += quest.XpReward;
            Player.QuestsBook.Remove(quest);
        }

        public void TakeQuest(Quest quest)
        {
            if (quest.GetType() == typeof(CollectQuest))
            {
                CollectQuest collecquest = (CollectQuest)quest;
                GameMap.MapLayout[collecquest.PositionI][collecquest.PositionJ].IsACollectDestination = true;
            }
            Player.QuestsBook.Add(quest);
            GameMap.MapLayout[Player.PositionI][Player.PositionJ].MisterQuest.Quests.Remove(quest);
        }

        //gestion du menu de droite pour les quetes et inventaire.


        public void SwitchShowQuestList()
        {
            ShowInventory = false;
            ShowQuestList = true;
            ShowQuestGiver = false;
        }

        public void SwitchShowInventoryList()
        {
            ShowInventory = true;
            ShowQuestList = false;
            ShowQuestGiver = false;
        }

        public void SwitchShowQuestGiver()
        {
            ShowQuestGiver = true;
            ShowQuestList = false;
            ShowInventory = false;
        }

        //Gestion des combats

        //Fonction qui va vérifier si le déplacement provoque un combat ou pas.

        private void IsFight(Square localisation)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if (randomNumber < localisation.ChanceToTriggerFight)
            {
                MonsterFight = SelectEnemy();
                IsCurrentFight = true;
                FormShow = TypeOfShow.Fight;
            }
        }

        public void Action(Spells spell, Game game)
        {
            if (game.MonsterFight.MonsterBreed != TypeOfBreed.RicoChico || (game.Player.Wukongdead && game.Player.Tontatondead && game.Player.Joydead && game.Player.Scorpiodead))
            {
                FightMessage = spell.UseSpell(Player, MonsterFight);
                FightMessage += " ";
                Turncount++;
                if (Player2 == null || Player2.CurrentHitPoints <= 0)
                {
                    Turncount++;
                }
            }
            if (game.MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (game.MonsterFight.IsBurning && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre perd 10% hp si il brûle
            {
                FightMessage += "La cible brûle et subit " + game.MonsterFight.BurnTic() + " points de dégâts ! ";
                if (game.MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                {
                    FightVictory();
                }
                else
                {
                    MonsterHit();
                }
            }
            else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! " && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre passe son tour si le joueur est con
            {
                MonsterHit();
            }
            else if (game.MonsterFight.IsFrozen && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre ne joue pas si gelé
            {
                FightMessage += "Vous avez gelé la cible !";
                game.MonsterFight.Frozen(); //dégèle
            }
        }

        public void ActionPlayer2(Spells spell, Game game)
        {
            FightMessage = spell.UseSpell(Player2, MonsterFight);
            FightMessage += " ";
            Turncount++;

            if (game.MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (game.MonsterFight.IsBurning) //Le monstre perd 10% hp si il brûle
            {
                FightMessage += "La cible brûle et subit " + game.MonsterFight.BurnTic() + " points de dégâts ! ";
                if (game.MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                {
                    FightVictory();
                }
                else
                {
                    MonsterHit();
                }
            }
            else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! ") //Le monstre passe son tour si le joueur est con
            {
                MonsterHit();
            }
            else if (game.MonsterFight.IsFrozen) //Le monstre ne joue pas si gelé
            {
                FightMessage += "Vous avez gelé la cible !";
                game.MonsterFight.Frozen(); //dégèle
            }
        }


        public void UseWeapon(Monster target, Game game)
        {
            if (target.MonsterBreed != TypeOfBreed.RicoChico || (Player.Wukongdead && Player.Tontatondead && Player.Joydead && Player.Scorpiodead))
            {
                FightMessage = Player.Hit(target);
                FightMessage += " ";
                Turncount++;
                if (Player2 == null || Player2.CurrentHitPoints <= 0)
                {
                    Turncount++;
                }
            }
            if (game.MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (game.MonsterFight.IsBurning && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre perd 10% hp si il brûle
            {
                FightMessage += "La cible brûle et subit " + game.MonsterFight.BurnTic() + " points de dégâts ! ";
                if (game.MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                {
                    FightVictory();
                }
                else
                {
                    MonsterHit();
                }
            }
            else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! " && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre passe son tour si le joueur est con
            {
                MonsterHit();
            }
            else if (game.MonsterFight.IsFrozen && (Player2 == null || Player2.CurrentHitPoints <= 0)) //Le monstre ne joue pas si gelé
            {
                FightMessage += "Vous avez gelé la cible !";
                game.MonsterFight.Frozen(); //dégèle
            }
        }

        public void UseWeaponPlayer2(Monster target, Game game)
        {
            FightMessage = Player2.Hit(target);
            FightMessage += " ";
            Turncount++;
            if (game.MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (game.MonsterFight.IsBurning) //Le monstre perd 10% hp si il brûle
            {
                FightMessage += "La cible brûle et subit " + game.MonsterFight.BurnTic() + " points de dégâts ! ";
                if (game.MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                {
                    FightVictory();
                }
                else
                {
                    MonsterHit();
                }
            }
            else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! ") //Le monstre passe son tour si le joueur est con
            {
                MonsterHit();
            }
            else if (game.MonsterFight.IsFrozen) //Le monstre ne joue pas si gelé
            {
                FightMessage += "Vous avez gelé la cible !";
                game.MonsterFight.Frozen(); //dégèle
            }
        }
        private void FightVictory()
        {
            MonsterFight.MonsterCurrentHP = 0;
            FightMessage += "Cela suffit à vaincre le monstre, cette victoire vous rapporte " + MonsterFight.XpGranted +
                " points d'expérience ! ";
            FightMessage += CheckQuest();
            if (MonsterFight.MonsterBreed == TypeOfBreed.RicoChico)
            {
                GameMap.MapLayout[246][250].ChanceToTriggerFight = 0.0;
            }
            Player.CurrentXp += MonsterFight.XpGranted;
            Player2.CurrentXp += MonsterFight.XpGranted;
            if (new Random().Next(0, 2) == 1 || MonsterFight.MonsterBreed == TypeOfBreed.RicoChico)
            {
                Stuff droppedItem = MonsterFight.DropItem();
                Player.LootStuff(droppedItem);
                FightMessage += "Vous trouvez '" + droppedItem.ItemName + "' sur le cadavre de votre ennemi ! ";
            }
            MonsterDead = true;
            if (Player.CurrentXp >= Player.XpToLevel)
            {
                LevelUp(Player);
            }
            if (Player2.CurrentXp >= Player2.XpToLevel)
            {
                LevelUp(Player2);
            }
        }

        private string CheckQuest()
        {
            string message = "";
            foreach (var quest in Player.QuestsBook)
            {
                if (MonsterFight.MonsterBreed == quest.Target)
                {
                    quest.status = true;
                    message = " Cela vous permet aussi de valider une quête. ";
                }
            }
            return message;
        }

        public void MonsterHit()
        {
            if (MonsterFight.MonsterBreed == TypeOfBreed.RicoChico && !Player.Joydead && !Player.Scorpiodead && !Player.Tontatondead && !Player.Wukongdead)
            {
                FightMessage = "Vous touchez le grand Rico Chico mais il vous rit au nez et vous balaye d'une main. Vous êtes Ko. Revenez après avoir reconstruit la relique";
                Player.CurrentHitPoints = 0;
                PlayerDead = true;
                Player.CurrentXp /= 2;
            }
            else
            {
                int whoGetsHit = new Random().Next(0, 2);
                if(whoGetsHit == 0 && Player2.CurrentHitPoints > 0)
                {
                    FightMessage += MonsterFight.Hit(Player2);
                }
                else
                {
                    FightMessage += MonsterFight.Hit(Player);
                }
                if (Player.CurrentHitPoints <= 0 && !MonsterDead)
                {
                    Player.CurrentHitPoints = 0;
                    PlayerDead = true;
                    FightMessage = "Vous êtes mort, des goblins sortent de l'ombre pour vous emmener rapidement dans le dernier village que vous avez visité. ";
                    FightMessage += "Vous perdez la moitié de votre expérience. ";
                    Player.CurrentXp /= 2;
                }
            }
        }
        public void SwitchFightSpells()
        {
            ShowFightSpells = true;
            ShowFightInventory = false;
        }

        public void SwitchFightInventory()
        {
            ShowFightInventory = true;
            ShowFightSpells = false;
        }

        //Fonction qui va choisir aléatoirement un monstre dans le pool du Biome
        private Monster SelectEnemy()
        {
            List<Type> list = GameMap.MapLayout[Player.PositionI][Player.PositionJ].SquareBiome.MonsterPool;
            Type randomClassType = list[new Random().Next(list.Count)];
            dynamic monster = Activator.CreateInstance(randomClassType);
            FightMessage = "Vous êtes agressé par " + monster.MonsterName + ", il faut le vaincre pour survivre.";
            return monster;
        }

        //gestion de l'équipe
        public void PartyRest()
        {
            Player.Rest();
            Player2.Rest();
        }

        public void Recrut(Character player)
        {
            Player2 = player;
        }

        public void Solo()
        {
            Player2 = null;
        }


        //Gestion de déplacement et de trigger fight
        public void GoUp(Game game)
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (game.Player.PositionI > 0)
            {
                game.Player.PositionI--;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoDown(Game game)
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (game.Player.PositionI < 499)
            {
                game.Player.PositionI++;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoLeft(Game game)
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (game.Player.PositionJ > 0)
            {
                game.Player.PositionJ--;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoRight(Game game)
        {
            if (ShowQuestGiver)
            {
                SwitchShowInventoryList();
            }
            if (game.Player.PositionJ < 499)
            {
                game.Player.PositionJ++;
                GameMap.UpdateMapDisplay(Player);
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }
    }
}
