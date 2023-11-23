namespace LegendOfRico.Data
{
    public class Map
    {
        public Square[][] MapLayout { get; } = CreateMapLayout();
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
            if (MaxI > 500) { MaxI = 500; }
            if (MaxJ > 500) { MaxJ = 500; }
        }

        //création des monstres 
        //encore à définir et modifer les pools en fonction
        public static Undead skeleton = new Undead { Name = "Skeleton" };


        // création des pool de monstres, 4 pools par biomes, trois en fonction du niveau de la map et un pour les boss
        //contenu des pool encore à définir mais divers pool déjà créés pour faire la map
        //plaine
        public static Monster[] poolOfPlain = { skeleton, skeleton };
        public static Monster[] poolOfMediumPlain = { skeleton, skeleton };
        public static Monster[] poolOfHardPlain = { skeleton, skeleton };
        //forêt
        public static Monster[] poolOfForest = { skeleton, skeleton };
        public static Monster[] poolOfMediumForest = { skeleton, skeleton };
        public static Monster[] poolOfHardForest = { skeleton, skeleton };
        public static Monster[] bossOfForest = { skeleton, skeleton };
        //désert
        public static Monster[] poolOfDesert = { skeleton, skeleton };
        public static Monster[] poolOfMediumDesert = { skeleton, skeleton };
        public static Monster[] poolOfHardDesert = { skeleton, skeleton };
        public static Monster[] bossOfDesert = { skeleton, skeleton };
        //Ruines
        public static Monster[] poolOfRuined = { skeleton, skeleton };
        public static Monster[] poolOfMediumRuined = { skeleton, skeleton };
        public static Monster[] poolOfHardRuined = { skeleton, skeleton };
        public static Monster[] bossOfRuined = { skeleton, skeleton };
        //cimetiere
        public static Monster[] poolOfGraveyard = { skeleton, skeleton };
        public static Monster[] poolOfMediumGraveyard = { skeleton, skeleton };
        public static Monster[] poolOfHardGraveyard = { skeleton, skeleton };
        public static Monster[] bossOfGraveyard = { skeleton, skeleton };
        //village
        public static Monster[] poolOfVillage = { skeleton, skeleton };
        public static Monster[] poolOfMediumVillage = { skeleton, skeleton };
        public static Monster[] poolOfHardVillage = { skeleton, skeleton };
        public static Monster[] bossOfVillage = { skeleton, skeleton };

        //création des différents Biomes 3 par types pour les différentes images et un pour les boss sauf pour le village ou il n'en faut pas 3 pour les images
        //Plaine
        public static Biomes plain = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine.png" };
        public static Biomes plain1 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine1.png" };
        public static Biomes plain2 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine2.png" };
        //forêt
        public static Biomes forest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret.png" };
        public static Biomes forest1 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret1.png" };
        public static Biomes forest2 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret2.png" };
        public static Biomes bossForest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = bossOfForest, ImageUrl = "img/biomes/foretBoss.jpg" };
        //désert
        public static Biomes desert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert.png" };
        public static Biomes desert1 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert1.png" };
        public static Biomes desert2 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert2.png" };
        public static Biomes bossDesert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = bossOfDesert, ImageUrl = "img/biomes/desertBoss.png" };
        //ruines
        public static Biomes ruinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine.png" };
        public static Biomes ruinedVillage1 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine1.png" };
        public static Biomes ruinedVillages2 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine2.png" };
        public static Biomes bossRuinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = bossOfRuined, ImageUrl = "img/biomes/ruineBoss.jpg" };
        //cimetiere
        public static Biomes graveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere.png" };
        public static Biomes graveyard1 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere1.png" };
        public static Biomes graveyard2 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere2.png" };
        public static Biomes bossGraveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = bossOfGraveyard, ImageUrl = "img/biomes/cimetiereBoss.jpg" };
        //village
        public static Biomes village = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = poolOfVillage, ImageUrl = "img/biomes/village.png" };
        public static Biomes bossVillage = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = bossOfVillage, ImageUrl = "img/biomes/villageBoss.jpg" };


        
        

        //création des squares classic à supprimer après

        public static Square classicForest = new Square { SquareBiome = forest, Name = "classicForet", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicForest1 = new Square { SquareBiome = forest1, Name = "classicForet", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicForest2 = new Square { SquareBiome = forest2, Name = "classicForet", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicDesert = new Square { SquareBiome = desert, Name = "classicDesert", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicVillage = new Square { SquareBiome = village, Name = "classicVillage", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicRuined = new Square { SquareBiome = ruinedVillage, Name = "classicRuined", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square classicGraveyard = new Square { SquareBiome = graveyard, Name = "classicGraveyard", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square squareBossForest = new Square { SquareBiome = forest, Name = "bossForet", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square squareBossDesert = new Square { SquareBiome = desert, Name = "bossDesert", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square squareBossVillage = new Square { SquareBiome = village, Name = "bossVillage", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square squareBossRuined = new Square { SquareBiome = ruinedVillage, Name = "bossRuined", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
        public static Square squareBossGraveyard = new Square { SquareBiome = graveyard, Name = "bossGraveyard", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };

        //création de villes

        public static Square astrubVillage = new Square { SquareBiome = village, Name = "Astrub", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };

        //fonction de création de la map qui retourne une matrice de 500 sur 500 remplies de squares et qui sera appellée dans le paramère mapLayout

        private static Square[][] CreateMapLayout()
        {
            Square[][] mapLayout = new Square[500][];

            for (int i = 0; i < 500; i++)
            {
                mapLayout[i] = new Square[500];

                for (int j = 0; j < 500; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Foret Tranquille", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Foret Tranquille", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false }; 
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Foret Tranquille", ChanceToTriggerFight = 0.0, HasNPC = false, HasQuestTarget = false }; 
                    }
                }
            }

            //ajout de la ville de départ astrub
            mapLayout[250][250] = astrubVillage;

            return mapLayout;
        }
    }
}
