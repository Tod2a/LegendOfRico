namespace LegendOfRico.Data
{
    public class CollectQuest : Quest
    {
        public TypeOfBiome LocalBiome { get; set; }
        Random Random { get; set; } = new Random();
        public string Imgurl { get; set; }
        public int NumberOfMonster { get; set; } = 10;
        public int NumberOfTarget { get; set; } = 10;
        public Square[][] CollectMap { get; set; }
        public int PositionI { get; set; }
        public int PositionJ { get; set; }
        public CollectQuest(string questName, string description, int xpreward, int coinreward, int positioni, int positionj, TypeOfBiome localBiome)
            : base(questName, description, xpreward, coinreward)
        {
            PositionI = positioni;
            PositionJ = positionj;
            LocalBiome = localBiome;
            Imgurl = SetUrl(localBiome);
            CollectMap = DisplayMap(localBiome);
        }

        private Square[][] DisplayMap (TypeOfBiome localBiome)
        {
            int posi;
            int posj;
            Square[][] map = new Square[20][];
            List<Type> pool = new List<Type>();
            Biomes biomes = new Biomes(localBiome, pool, Imgurl, Imgurl);
            for(int i = 0; i<20;i++)
            {
                map[i] = new Square[20];
                for (int j = 0; j< 20;j++)
                {
                    map[i][j] = new Square { SquareBiome = biomes};
                }
            }
            for(int i = 0; i < NumberOfMonster; i++)
            {
                posi = Random.Next(0, 20);
                posj = Random.Next(0, 20);
                map[posi][posj].HasMonsterCollectQuest = true;
            }
            for (int i = 0; i < NumberOfTarget; i++)
            {
                do {
                    posi = Random.Next(0, 20);
                    posj = Random.Next(0, 20);
                } while (map[posi][posj].HasMonsterCollectQuest);
                map[posi][posj].HasQuestTarget = true;
            }

            return map;
        }

        private string SetUrl(TypeOfBiome localBiome)
        {
            switch (localBiome)
            {
                case TypeOfBiome.Forest:
                    return "img/biomes/foret.png";
                case TypeOfBiome.Graveyard:
                    return "img/biomes/cimetiere.png";
                case TypeOfBiome.Desert:
                    return "img/biomes/desert.png";
                case TypeOfBiome.AbandonedVillage:
                    return "img/biomes/ruine.png";
                case TypeOfBiome.ForestDifficult:
                    return "img/biomes/foret3.png";
                case TypeOfBiome.GraveyardDifficult:
                    return "img/biomes/cimetiere3.png";
                case TypeOfBiome.DesertDifficult:
                    return "img/biomes/desert3.png";
                case TypeOfBiome.AbandonedVillageDifficult:
                    return "img/biomes/ruine3.png";
                default:
                    return "img/biomes/plaine.png";
            }
        }
    }
}
