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
        private bool showConnection = true;
        private bool showGame = false;
        private bool showFight = false;
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

        public static void Deconnection(Game game)
        {
            game.FormShow = TypeOfShow.Connection;
        }

        //Gestion des combats
        //creation d'une fonction temporaire pour quitter la page de combat
        public static void FightWin(Game game)
        {
            game.FormShow = TypeOfShow.Map;
        }

        //Fonction qui va vérifier si le déplacement provoque un combat ou pas.
        private static void IsFight(Game game, Square localisation)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if(randomNumber < localisation.ChanceToTriggerFight)
            {
                game.MonsterFight = SelectEnemy(game);
                game.FormShow = TypeOfShow.Fight;
            }
        }

        //Fonction qui va choisir aléatoirement un monstre dans le pool du Biome
        private static Monster SelectEnemy(Game game)
        {
            Random random = new Random();
            int indexAleatoire = random.Next(game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ].SquareBiome.MonsterPool.Length);
            return game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ].SquareBiome.MonsterPool[indexAleatoire];
        }

        

        //Gestion de déplacement et de trigger fight
        public void GoUp(Game game)
        {
            if (game.Player.PositionI > 0)
            {
                game.Player.PositionI--;
                IsFight(game, game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ]);
            }
        }

        public void GoDown(Game game)
        {
            if (game.Player.PositionI < 499)
            {
                game.Player.PositionI++;
                IsFight(game, game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ]);
            }
        }

        public void GoLeft(Game game)
        {
            if (game.Player.PositionJ > 0)
            {
                game.Player.PositionJ--;
                IsFight(game, game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ]);
            }
        }

        public void GoRight(Game game)
        {
            if (game.Player.PositionJ < 499)
            {
                game.Player.PositionJ++;
                IsFight(game, game.GameMap.MapLayout[game.Player.PositionI][game.Player.PositionJ]);
            }
        }


        

    }
}
