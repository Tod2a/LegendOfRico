using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using Microsoft.JSInterop;

namespace LegendOfRico.Data
{
    //Class "main" qui va permettre de développer les interactions entre le Player et la map tel que les combats, les savings etc
    public class Game
    {
        public Map GameMap { get; set; } = new Map();
        public Character Player { get; set; } = new Wizard { };
        private bool showConnection = true;
        private bool showGame = false;
        private bool showFight = false;
        public TypeOfShow FormShow { get; set; } = TypeOfShow.Connection;





        public void CreateCharacter(string CName, TypeOfCharacter Type)
        {
            Player = MakeCharacter(CName, Type);
            FormShow = TypeOfShow.Map;

            
        }

        private static Character MakeCharacter(string CName, TypeOfCharacter Type)
        {
            if (Type == TypeOfCharacter.Magicien)
            {
                return new Wizard { Name = CName, MapSprite = "img/character/spriteWizard.png" };
            }
            else if (Type == TypeOfCharacter.Guerrier)
            {
                return new Fighter { Name = CName, MapSprite = "img/character/spriteFighter.png" };
            }
            else if (Type == TypeOfCharacter.Voleur)
            {
                return new Rogue { Name = CName, MapSprite = "img/character/spriteRogue.png" };
            }
            else if (Type == TypeOfCharacter.clerc) 
            {
                return new Cleric { Name = CName, MapSprite = "img/character/spriteCleric.png" };
            }
            else
            {
                return new Ranger { Name = CName, MapSprite = "img/character/spriteRanger.png" };
            }
        }
        public static void Deconnection(Game game)
        {
            game.FormShow = TypeOfShow.Connection;
        }

        public void GoUp()
        {
            if (Player.PositionI > 0)
            {
                Player.PositionI--;
            }
        }

        public void GoDown()
        {
            if (Player.PositionI < 499)
            {
                Player.PositionI++;
            }
        }

        public void GoLeft()
        {
            if (Player.PositionJ > 0)
            {
                Player.PositionJ--;
            }
        }

        public void GoRight()
        {
            if (Player.PositionJ < 499)
            {
                Player.PositionJ++;
            }
        }


        

    }
}
