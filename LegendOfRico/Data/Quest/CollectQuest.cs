namespace LegendOfRico.Data
{
    public class CollectQuest : Quest
    {
        public TypeOfBiome LocalBiome { get; set; }
        Random Random { get; set; } = new Random();
        public string Imgurl { get; set; }
        public string MonsterUrl { get; set; } = "img/Collect/Monstre.png";
        public string TargetUrl { get; set; }
        //Initialisation des paramètres de collecte, il y aura toujours 10 cibles et 10 monstres dans les quêtes de collecte
        public int NumberOfMonster { get; set; } = 10;
        public int NumberOfTarget { get; set; } = 10;
        public int CurrentTarget { get; set; } = 10;
        public bool QuestEnd { get; set; } = false;
        public Square[][] CollectMap { get; set; }
        public int PositionI { get; set; }
        public int PositionJ { get; set; }

        //Ajout des informations necessaire dans le construceur, la position de la quête et son biome
        public CollectQuest(string questName, string description, int xpreward, int coinreward, int positioni, int positionj, TypeOfBiome localBiome)
            : base(questName, description, xpreward, coinreward)
        {
            PositionI = positioni;
            PositionJ = positionj;
            LocalBiome = localBiome;
            Imgurl = SetUrl(localBiome);
            TargetUrl = SetTargetUrl(localBiome);
        }

        //Fonction de création de la map de collect qui sera générée à chaque tentative
        public void DisplayMap ()
        {
            int posi;
            int posj;
            //Création d'une map de 10 lignes et d'un pool vide pour le biome de collecte
            Square[][] map = new Square[10][];
            List<Monster> pool = new List<Monster>();
            Biomes biomes = new Biomes(LocalBiome, pool, Imgurl, Imgurl);
            //Création de chaque lignes de la map qui contiendra 10 square
            for(int i = 0; i<10;i++)
            {
                map[i] = new Square[10];
                for (int j = 0; j< 10;j++)
                {
                    map[i][j] = new Square { SquareBiome = biomes};
                }
            }
            //Implantation des 10 monstres qui ne peuvent pas se trouver sur la case de départ du personnage (0,5)
            //Si 2 monstres son généré sur la même case, c'est que la chance du personnage a joué en sa faveur
            for(int i = 0; i < NumberOfMonster; i++)
            {
                do {
                    posi = Random.Next(0, 10);
                    posj = Random.Next(0, 10);
                } while (posi == 0 && posj == 5);
                map[posi][posj].HasMonsterCollectQuest = true;
            }
            //Implantation des 10 cibles qui ne peuvent ni être en (0,5) ni sur un monstre, ni 2 cibles au même endroit
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

        //Automatisation de l'image de fond de la quête en fonction du biome ciblé
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

        //Automatisation de l'image de la cible de la collecte en fonction du biome ciblé
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
