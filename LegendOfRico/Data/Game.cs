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
        public Monster MonsterFight { get; set; }
        public Merchant Merchant { get; set; } = new Merchant();
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
        public TypeOfShow FormShow { get; set; } = TypeOfShow.Connection;



        public void LevelUp()
        {
            GameMap.MapLevel++;
            Player.Level++;
            FightMessage += "Vous gagnez un niveau !";
            Player.CurrentXp -= Player.XpToLevel;
            Player.XpToLevel += 250 * Player.Level;
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

        public void ValidQuest (Quest quest)
        {
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

        public void TakeQuest (Quest quest)
        {
            Player.QuestsBook.Add(quest);
            GameMap.MapLayout[Player.PositionI][Player.PositionJ].MisterQuest.Quests.Remove(quest);
        }

        //gestion du menu de droite pour les quetes et inventaire.


        public void SwitchShowQuestList ()
        {
            ShowInventory = false;
            ShowQuestList = true;
            ShowQuestGiver = false;
        }

        public void SwitchShowInventoryList ()
        {
            ShowInventory = true;
            ShowQuestList = false;
            ShowQuestGiver = false;
        }

        public void SwitchShowQuestGiver ()
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
            if(randomNumber < localisation.ChanceToTriggerFight)
            {
                MonsterFight = SelectEnemy();
                FormShow = TypeOfShow.Fight;
            }
        }

        public void Action(Spells spell, Game game)
        {
            FightMessage = spell.UseSpell(game);
            FightMessage += " ";
            if (game.MonsterFight.MonsterCurrentHP <= 0)
            {
                FightVictory();
            }
            else if (game.MonsterFight.IsBurning) //Le monstre perd 10% hp si il brûle
            {
                FightMessage += "La cible brûle et subit "+game.MonsterFight.BurnTic()+" points de dégâts ! ";
                if (game.MonsterFight.MonsterCurrentHP <= 0) //Check si meurt avec brûlure
                {
                    FightVictory();
                }
                else
                {
                    MonsterHit(game);
                }
            }
            else if(FightMessage != "Vous ne pouvez plus lancer ce sort ! ") //Le monstre passe son tour si le joueur est con
            {
                MonsterHit(game);
            }
            else if(game.MonsterFight.IsFrozen) //Le monstre ne joue pas si gelé
            {
                FightMessage += "Vous avez gelé la cible !";
                game.MonsterFight.Frozen(); //dégèle
            }
        }

        public void UseWeapon (Monster target, Game game)
        {
            FightMessage = Player.Hit(target);
            FightMessage += " ";
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
                    MonsterHit(game);
                }
            }
            else if (FightMessage != "Vous ne pouvez plus lancer ce sort ! ") //Le monstre passe son tour si le joueur est con
            {
                MonsterHit(game);
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
            FightMessage += "cela suffit à vaincre le monstre, cette victoire vous rapporte " + MonsterFight.XpGranted +
                " points d'expérience ! ";
            FightMessage += CheckQuest();
            if(MonsterFight.MonsterBreed == TypeOfBreed.RicoChico)
            {
                GameMap.MapLayout[246][250].ChanceToTriggerFight = 0.0;
            }
            Player.CurrentXp += MonsterFight.XpGranted;
            MonsterDead = true;
            if (Player.CurrentXp >= Player.XpToLevel)
            {
                LevelUp();
            }
        }

        private string CheckQuest()
        {
            string message = "";
            foreach (var quest in Player.QuestsBook)
            {
                if(MonsterFight.MonsterBreed == quest.Target)
                {
                    quest.status = true;
                    message = " Cela vous permet aussi de valider une quête.";
                }
            }
            return message;
        }

        public void MonsterHit(Game game)
        {
            if (MonsterFight.MonsterBreed == TypeOfBreed.RicoChico && !Player.Joydead && !Player.Scorpiodead && !Player.Tontatondead && !Player.Wukongdead)
            {
                FightMessage = "Vous toucher le grand Rico Chico mais il vous rit au nez et vous balaye d'une main. Vous êtes Ko. Revener après avoir reconstruit la relique";
                Player.CurrentHitPoints = 0;
                PlayerDead = true;
                Player.CurrentXp = 0;
            }
            else
            {
                game.FightMessage += game.MonsterFight.Hit(game.Player);
                if (game.Player.CurrentHitPoints <= 0 && !MonsterDead)
                {
                    game.Player.CurrentHitPoints = 0;
                    game.PlayerDead = true;
                    game.FightMessage = "Vous êtes mort, des gobelins sortent de l'ombre pour vous emmener rapidement dans le dernier village que vous avez visité.";
                    game.FightMessage += "Vous perdez toute votre expérience";
                    game.Player.CurrentXp = 0;
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

        

        //Gestion de déplacement et de trigger fight
        public void GoUp(Game game)
        {
            if (game.Player.PositionI > 0)
            {
                game.Player.PositionI--;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoDown(Game game)
        {
            if (game.Player.PositionI < 499)
            {
                game.Player.PositionI++;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoLeft(Game game)
        {
            if (game.Player.PositionJ > 0)
            {
                game.Player.PositionJ--;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }

        public void GoRight(Game game)
        {
            if (game.Player.PositionJ < 499)
            {
                game.Player.PositionJ++;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
        }
    }
}
