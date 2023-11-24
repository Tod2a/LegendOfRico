using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using Newtonsoft.Json;
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
        public bool ShowConnection
        {
            get => showConnection;
            set
            {
                if (showConnection != value)
                {
                    showConnection = value;
                    OnPropertyChanged(nameof(ShowConnection));
                }
            }
        }

        public bool ShowGame
        {
            get => showGame;
            set
            {
                if (showGame != value)
                {
                    showGame = value;
                    OnPropertyChanged(nameof(ShowGame));
                }
            }
        }

        public bool ShowFight
        {
            get => showFight;
            set
            {
                if (showFight != value)
                {
                    showFight = value;
                    OnPropertyChanged(nameof(ShowFight));
                }
            }
        }





        public void CreateCharacter(string CName, TypeOfCharacter Type)
        {
            Player = MakeCharacter(CName, Type);
            ShowConnection = false;
            ShowGame = true;

            OnPropertyChanged(nameof(Player));
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
                game.ShowConnection = true;
                game.ShowGame = false;
        }
        



        //Pour créer l'évenement de changement de form entre connexion, map et combat

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
