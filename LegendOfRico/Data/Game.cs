using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;

namespace LegendOfRico.Data
{
    //Class "main" qui va permettre de développer les interactions entre le Player et la map tel que les combats, les savings etc
    public class Game
    {
        public Map GameMap { get; set; } = new Map();
        public Character Player { get; set; }
        private bool showConnection = false;
        private bool showGame = true;
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



        public static void SwitchForm(Game game)
        {
            if (game.ShowConnection == false)
            {
                game.ShowConnection = true;
                game.ShowGame = false;
            }
            else
            {
                game.ShowConnection = false;
                game.ShowGame = true;
            }
        }



        //Pour créer l'évenement de changement de form entre connexion, map et combat

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
