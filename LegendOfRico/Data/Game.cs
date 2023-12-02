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
        public string FightMessage { get; set; } = "";
        //série de paramètres/variables qui vont gérer l'affichage des différents display du jeu
        //gestion du menu de droite
        public bool ShowInventory = true;
        public bool ShowQuestList = false;
        public bool ShowMerchantList = false;
        //gestion de l'interface de combat
        public bool ShowFightSpells = true;
        public bool ShowFightInventory = false;
        public TypeOfShow FormShow { get; set; } = TypeOfShow.Connection;





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
            else if (Type == TypeOfCharacter.clerc)
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

        //gestion du menu de droite pour les quetes, inventaire et marchand.

        public void SwitchShowMerchantList ()
        {
            ShowInventory = false;
            ShowMerchantList = true;
            ShowQuestList = false;
        }

        public void SwitchShowQuestList ()
        {
            ShowInventory = false;
            ShowMerchantList = false;
            ShowQuestList = true;
        }

        public void SwitchShowInventoryList ()
        {
            ShowInventory = true;
            ShowMerchantList = false;
            ShowQuestList = false;
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
            Random random = new Random();
            int indexAleatoire = random.Next(GameMap.MapLayout[Player.PositionI][Player.PositionJ].SquareBiome.MonsterPool.Length);
            Monster monster = GameMap.MapLayout[Player.PositionI][Player.PositionJ].SquareBiome.MonsterPool[indexAleatoire];
            FightMessage = "Vous êtes agrréssé par " + monster.MonsterName + " il faut le vaincre pour survivre.";
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
            if (game.ShowMerchantList == true)
            {
                Game.SwitchShowInventoryList(game);
            }
        }

        public void GoDown(Game game)
        {
            if (game.Player.PositionI < 499)
            {
                game.Player.PositionI++;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
            if (game.ShowMerchantList == true)
            {
                Game.SwitchShowInventoryList(game);
            }
        }

        public void GoLeft(Game game)
        {
            if (game.Player.PositionJ > 0)
            {
                game.Player.PositionJ--;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
            if (game.ShowMerchantList == true)
            {
                Game.SwitchShowInventoryList(game);
            }
        }

        public void GoRight(Game game)
        {
            if (game.Player.PositionJ < 499)
            {
                game.Player.PositionJ++;
                IsFight(GameMap.MapLayout[Player.PositionI][Player.PositionJ]);
            }
            if (game.ShowMerchantList == true)
            {
                Game.SwitchShowInventoryList(game);
            }
        }


        

    }
}
