namespace LegendOfRico.Data
{
    public class CollectQuest : Quest
    {
        public TypeOfBiome LocalBiome { get; set; }
        Random Random { get; set; } = new Random();
        public string Imgurl { get; set; }
        public string MonsterUrl { get; set; } = "img/Collect/Monstre.png";
        public string TargetUrl { get; set; }
        public int NumberOfMonster { get; set; } = 10;
        public int NumberOfTarget { get; set; } = 10;
        public int CurrentTarget { get; set; } = 10;
        public bool QuestEnd { get; set; } = false;
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
            TargetUrl = SetTargetUrl(localBiome);
        }

        public void DisplayMap ()
        {
            int posi;
            int posj;
            Square[][] map = new Square[10][];
            List<Type> pool = new List<Type>();
            Biomes biomes = new Biomes(LocalBiome, pool, Imgurl, Imgurl);
            for(int i = 0; i<10;i++)
            {
                map[i] = new Square[10];
                for (int j = 0; j< 10;j++)
                {
                    map[i][j] = new Square { SquareBiome = biomes};
                }
            }
            for(int i = 0; i < NumberOfMonster; i++)
            {
                do {
                    posi = Random.Next(0, 10);
                    posj = Random.Next(0, 10);
                } while (posi == 0 && posj == 5);
                map[posi][posj].HasMonsterCollectQuest = true;
            }
            for (int i = 0; i < NumberOfTarget; i++)
            {
                do {
                    posi = Random.Next(0, 10);
                    posj = Random.Next(0, 10);
                } while (map[posi][posj].HasMonsterCollectQuest || (posi == 0 && posj == 5) || map[posi][posj].HasQuestTarget);
                map[posi][posj].HasQuestTarget = true;
            }

            CollectMap = map;
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

        private string SetTargetUrl(TypeOfBiome localBiome)
        {
            switch (localBiome)
            {
                case TypeOfBiome.Forest:
                    return "img/Collect/foret.png";
                case TypeOfBiome.Graveyard:
                    return "img/Collect/cimetiere.png";
                case TypeOfBiome.Desert:
                    return "img/Collect/desert.png";
                case TypeOfBiome.AbandonedVillage:
                    return "img/Collect/ruine.png";
                case TypeOfBiome.ForestDifficult:
                    return "img/Collect/foret.png";
                case TypeOfBiome.GraveyardDifficult:
                    return "img/Collect/cimetiere.png";
                case TypeOfBiome.DesertDifficult:
                    return "img/Collect/desert.png";
                case TypeOfBiome.AbandonedVillageDifficult:
                    return "img/Collect/ruine.png";
                default:
                    return "img/Collect/plaine.png";
            }
        }
    }
}
