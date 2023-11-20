namespace LegendOfRico.Data
{
    public class Map
    {
        public Square[][] MapLayout { get; set; }
        //4 Variables necessaire à l'affichage de la map
        public int StartI { get; set; }
        public int MaxI { get; set; }
        public int StartJ { get; set; }
        public int MaxJ { get; set; }
        public int MapLevel { get; set; }
        public void LevelUpMap()
        {
            //A definir.
        }

        //Fonction qui va changer les valeurs d'affichage de map à chaque déplacement
        public void UpdateMapDisplay(Character PersoTest)
        {
            StartI = PersoTest.PositionI - 4;
            MaxI = PersoTest.PositionI + 5;
            StartJ = PersoTest.PositionJ - 4;
            MaxJ = PersoTest.PositionJ + 5;
            if (StartI<0) { StartI = 0; }
            if (StartJ < 0) { StartJ = 0; }
            if (MaxI > 20) { MaxI = 20; }
            if (MaxJ > 20) { MaxJ = 20; }
        }
    }
}
