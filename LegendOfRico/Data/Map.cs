using System.Collections.Specialized;

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
        public int MapLevel { get; set; } = 1;
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



        // tout ce qui suit sert à créer la map ainsi que son contenu

        //création des monstres 
        //encore à définir et modifer les pools en fonction
        public static Undead skeleton = new Undead { MonsterName = "Skeleton" };
        public static Undead Albatard = new Undead { MonsterName = "Albatard", MonsterHP = 5000 };
        public static Undead Boldel = new Undead { MonsterName = "Boldel", MonsterHP = 2500 };
        public static Undead Draleo = new Undead { MonsterName = "Draleo", MonsterHP = 1000 };

        public static Spider Aragorn = new Spider { MonsterName = "Aragorn", MonsterHP = 5000, fightImgUrl="img/monster/basicSpider.png"  };
        public static Spider SonOfAragorn = new Spider { MonsterName = "AragornJr", MonsterHP = 1000, fightImgUrl = "img/monster/basicSpider.png" };
        public static Spider CousinOfAragorn = new Spider { MonsterName = "Nrogara", MonsterHP = 2500, fightImgUrl = "img/monster/basicSpider.png" };


        // création des pool de monstres, 4 pools par biomes, trois en fonction du niveau de la map et un pour les boss
        //contenu des pool encore à définir mais divers pool déjà créés pour faire la map

        //plaine
        public static Monster[] poolOfPlain = { Aragorn };
        public static Monster[] poolOfMediumPlain = { Aragorn};
        public static Monster[] poolOfHardPlain = { Aragorn };
        //forêt
        public static Monster[] poolOfForest = { SonOfAragorn};
        public static Monster[] poolOfMediumForest = { CousinOfAragorn };
        public static Monster[] poolOfHardForest = { Aragorn };
        public static Monster[] bossOfForest = {Aragorn };
        //désert
        public static Monster[] poolOfDesert = { Aragorn };
        public static Monster[] poolOfMediumDesert = { Aragorn };
        public static Monster[] poolOfHardDesert = { Aragorn };
        public static Monster[] bossOfDesert = { Aragorn };
        //Ruines
        public static Monster[] poolOfRuined = { Aragorn };
        public static Monster[] poolOfMediumRuined = { Aragorn };
        public static Monster[] poolOfHardRuined = { Aragorn };
        public static Monster[] bossOfRuined = { Aragorn };
        //cimetiere
        public static Monster[] poolOfGraveyard = { Aragorn };
        public static Monster[] poolOfMediumGraveyard = { Aragorn };
        public static Monster[] poolOfHardGraveyard = { Aragorn };
        public static Monster[] bossOfGraveyard = { Aragorn };
        //village
        public static Monster[] poolOfVillage = { Aragorn };
        public static Monster[] poolOfMediumVillage = { Aragorn };
        public static Monster[] poolOfHardVillage = { Aragorn };
        public static Monster[] bossOfVillage = { Aragorn };

        //création des différents Biomes 3 par types pour les différentes images, un pour les cases dangereuses et un pour les boss
        //sauf pour le village et la plaine

        //Plaine
        public static Biomes plain = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine.png", FightUrl = "img/layout/fondFightPlaine.png" };
        public static Biomes plain1 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine1.png", FightUrl = "img/layout/fondFightPlaine.png" };
        public static Biomes plain2 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine2.png", FightUrl = "img/layout/fondFightPlaine.png" };
        //forêt
        public static Biomes forest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret.png", FightUrl = "img/layout/fondFightBois.png" };
        public static Biomes forest1 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret1.png", FightUrl = "img/layout/fondFightBois.png" };
        public static Biomes forest2 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret2.png", FightUrl = "img/layout/fondFightBois.png" };
        public static Biomes forest3 = new Biomes { BiomeType = TypeOfBiome.ForestDifficult, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret3.png", FightUrl = "img/layout/fondFightBois.png" };
        public static Biomes bossForest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = bossOfForest, ImageUrl = "img/biomes/foretBoss.png", FightUrl = "img/layout/fondFightBossBois.png" };
        //désert
        public static Biomes desert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes desert1 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert1.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes desert2 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert2.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes desert3 = new Biomes { BiomeType = TypeOfBiome.DesertDifficult, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert3.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes desert4 = new Biomes { BiomeType = TypeOfBiome.DesertDifficult, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert4.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes desert5 = new Biomes { BiomeType = TypeOfBiome.DesertDifficult, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert5.png", FightUrl = "img/layout/fondFightDesert.png" };
        public static Biomes bossDesert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = bossOfDesert, ImageUrl = "img/biomes/desertBoss.png", FightUrl = "img/layout/fondFightBossDesert.png" };
        //ruines
        public static Biomes ruinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine.png", FightUrl = "img/layout/fondFightRuine.png" };
        public static Biomes ruinedVillage1 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine1.png", FightUrl = "img/layout/fondFightRuine.png" };
        public static Biomes ruinedVillage2 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine2.png", FightUrl = "img/layout/fondFightRuine.png" };
        public static Biomes ruinedVillage3 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillageDifficult, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine3.png", FightUrl = "img/layout/fondFightRuine.png" };
        public static Biomes bossRuinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = bossOfRuined, ImageUrl = "img/biomes/ruineBoss.png", FightUrl = "img/layout/fondFightBossRuine.png" };
        //cimetiere
        public static Biomes graveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere.png", FightUrl = "img/layout/fondFightCimetiere.png" };
        public static Biomes graveyard1 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere1.png", FightUrl = "img/layout/fondFightCimetiere.png" };
        public static Biomes graveyard2 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere2.png", FightUrl = "img/layout/fondFightCimetiere.png" };
        public static Biomes graveyard3 = new Biomes { BiomeType = TypeOfBiome.GraveyardDifficult, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere3.png", FightUrl = "img/layout/fondFightCimetiere.png" };
        public static Biomes bossGraveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = bossOfGraveyard, ImageUrl = "img/biomes/cimetiereBoss.png", FightUrl = "img/layout/fondFightBossCimetiere.png" };
        //village
        public static Biomes village = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = poolOfVillage, ImageUrl = "img/biomes/village.png", FightUrl = "img/layout/fondFightBossVillage.png" };
        public static Biomes bossVillage = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = bossOfVillage, ImageUrl = "img/biomes/villageBoss.png", FightUrl = "img/layout/fondFightBossVillage.png" };
        public static Biomes village2 = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = poolOfVillage, ImageUrl = "img/biomes/village2.png" , FightUrl = "img/layout/fondFightBossVillage.png" };
        public static Biomes village3 = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = poolOfVillage, ImageUrl = "img/biomes/village3.png", FightUrl = "img/layout/fondFightBossVillage.png" };
    

        private static void TrippleSquare(int minI, int maxI, int minJ, int maxJ, Square[][] mapLayout, TypeOfBiome tBiome, string Name, double cTrigger)
        {
            Biomes b0 = plain;
            Biomes b1 = plain1;
            Biomes b2 = plain2;

            switch (tBiome)
            {
                case TypeOfBiome.Forest:
                    b0 = forest;
                    b1 = forest1;
                    b2 = forest2;
                    break;
                case TypeOfBiome.AbandonedVillage:
                    b0 = ruinedVillage;
                    b1 = ruinedVillage1;
                    b2 = ruinedVillage2;
                    break;
                case TypeOfBiome.Desert:
                    b0 = desert;
                    b1 = desert1;
                    b2 = desert2;
                    break;
                case TypeOfBiome.Graveyard:
                    b0 = graveyard;
                    b1 = graveyard1;
                    b2 = graveyard2;
                    break;
                case TypeOfBiome.DesertDifficult:
                    b0 = desert3;
                    b1 = desert4;
                    b2 = desert5;
                    break;
                case TypeOfBiome.GraveyardDifficult:
                    b0 = graveyard3;
                    b1 = graveyard3;
                    b2 = graveyard3;
                    break;
                case TypeOfBiome.AbandonedVillageDifficult:
                    b0 = ruinedVillage3;
                    b1 = ruinedVillage3;
                    b2 = ruinedVillage3;
                    break;
                case TypeOfBiome.ForestDifficult:
                    b0 = forest3;
                    b1 = forest3;
                    b2 = forest3;
                    break;

            }
            for (int i = minI; i < maxI; i++)
            {
                for (int j = minJ; j < maxJ; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = b2, Name = Name, ChanceToTriggerFight = cTrigger };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = b0, Name = Name, ChanceToTriggerFight = cTrigger };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = b1, Name = Name, ChanceToTriggerFight = cTrigger };
                    }
                }
            }

        }




        //fonction de création de la map qui retourne une matrice de 500 sur 500 remplies de squares et qui sera appellée dans le paramère mapLayout

        private static Square[][] CreateMapLayout()
        {
            Square[][] mapLayout = new Square[500][];
            // création de la map de base remplis de plaines
            for (int i = 0; i < 500; i++)
            {
                mapLayout[i] = new Square[500];

                for (int j = 0; j < 500; j++)
                {
                    //utilisation des 3 images différentes en fonction du modulo des coordonées de chaque square
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square {SquareBiome = plain2, Name = "Plaine tranquille", ChanceToTriggerFight = 0.025 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square {SquareBiome = plain, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.025 }; 
                    }
                    else
                    {
                        mapLayout[i][j] = new Square {SquareBiome = plain1, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.025 }; 
                    }
                }
            }



            //ajout d'une ruine au nord de la map

            TrippleSquare(0, 54, 161, 201, mapLayout, TypeOfBiome.AbandonedVillage, "Les ruines de raftool", 0.1);
            TrippleSquare(20, 32, 187, 194, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "Les ruines de raftool", 0.25);

            //ajout foret
            TrippleSquare(60, 110, 234, 327, mapLayout, TypeOfBiome.Forest, "Forêt de Nibel", 0.1);
            TrippleSquare(89, 101, 249, 265, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Nibel", 0.25);

            //ajout d'un désert

            TrippleSquare(165, 230, 24, 74, mapLayout, TypeOfBiome.Desert, "Les milles et une boucles", 0.1);
            TrippleSquare(184, 198, 43, 63, mapLayout, TypeOfBiome.DesertDifficult, "Les milles et une boucles", 0.25);

            //ajout d'un cimetiere nord-ouest de la map
            TrippleSquare(154, 198, 83, 180, mapLayout, TypeOfBiome.Graveyard, "Cimetière des héros", 0.1);

            //une forêt
            TrippleSquare(243, 312, 22, 110, mapLayout, TypeOfBiome.Forest, "Forêt de Yasopp", 0.1);

            //un désert
            TrippleSquare(61, 165, 157, 221, mapLayout, TypeOfBiome.Desert, "désert aride", 0.1);

            //une ruine
            TrippleSquare(121, 201, 231, 321, mapLayout, TypeOfBiome.AbandonedVillage, "ruines de zilda", 0.1);

            //une forêt
            TrippleSquare(154, 334, 375, 465, mapLayout, TypeOfBiome.Forest, "Forêt de Yasopp", 0.1);

            // un cimetiere
            TrippleSquare(387, 487, 178, 320, mapLayout, TypeOfBiome.Graveyard, "Cimetière sombre", 0.1);

            //une forêt
            TrippleSquare(268, 324, 275, 311, mapLayout, TypeOfBiome.Forest, "Forêt d'elwyne", 0.1);

            // un désert
            TrippleSquare(275, 323, 175, 212, mapLayout, TypeOfBiome.Desert, "désert humide", 0.1);

            
           
            //création des 4 zones importantes du jeu, celles des 4 boss

            //création de la foret de Sherloop qui habrite un des 4 boss du jeu
            TrippleSquare(0, 150, 0, 150, mapLayout, TypeOfBiome.Forest, "Forêt de sherloop", 0.1);

            //zone dangereuse de cette forêt
            TrippleSquare(20, 80, 10, 65, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Sherloop", 0.25);

            //deuxieme zone dangereuse de cette forêt
            TrippleSquare(90, 110, 110, 142, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Sherloop", 0.25);

            //zone de boss de la forêt
            mapLayout[72][53] = new Square { SquareBiome = bossForest, Name = "Sun Wukong", ChanceToTriggerFight = 1.0 };

           

            //création du désert Dune eternelle (référence à zelda et roi lion POG) qui habrite un des 4 boss du jeu
            TrippleSquare(349, 500, 349, 500, mapLayout, TypeOfBiome.Desert, "La dune éternelle", 0.1);

            //zone dangereuse de ce désert
            TrippleSquare(359, 372, 352, 369, mapLayout, TypeOfBiome.DesertDifficult, "La dune éternelle", 0.1);

            //deuxieme zone dangereuse de ce desert
            TrippleSquare(398, 431, 354, 365, mapLayout, TypeOfBiome.DesertDifficult, "La dune éternelle", 0.1);

            //troisieme zone dangereuse de ce desert
            TrippleSquare(357, 378, 378, 403, mapLayout, TypeOfBiome.DesertDifficult, "La dune éternelle", 0.1);

            //quatrieme zone dangereuse de ce desert
            TrippleSquare(469, 498, 476, 496, mapLayout, TypeOfBiome.DesertDifficult, "La dune éternelle", 0.1);

            //zone de boss de ce desert
            mapLayout[499][499] = new Square { SquareBiome = bossDesert, Name = "Le scorpion éternel", ChanceToTriggerFight = 1.0 };



            //création de l'ancienne cité de joy bean qui habrite un des 4 boss du jeu
            TrippleSquare(349, 500, 0, 150, mapLayout, TypeOfBiome.AbandonedVillage, "l'ancienne cité de Joy Bean", 0.1);

            //zone dangereuse de cette cité en ruine
            TrippleSquare(420, 468, 56, 98, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "l'ancienne cité de Joy Bean", 0.25);

            //deuxieme zone dangereuse de cette cité en ruine
            TrippleSquare(357, 376, 120, 135, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "l'ancienne cité de Joy Bean", 0.25);

            //zone de boss de cette cité en ruine
            mapLayout[428][58] = new Square { SquareBiome = bossRuinedVillage, Name = "Le grand Joy Bean", ChanceToTriggerFight = 1.0 };



            //création du Cimetière des tontaton qui habrite un des 4 boss du jeu
            TrippleSquare(0, 150, 349, 500, mapLayout, TypeOfBiome.Graveyard, "Cimetière des tontaton", 0.1);

            //zone dangereuse de ce cimetière
            TrippleSquare(20, 60, 390, 435, mapLayout, TypeOfBiome.GraveyardDifficult, "Cimetière des tontaton", 0.25);

            //deuxieme zone dangereuse de ce cimetiere
            TrippleSquare(90, 110, 369, 385, mapLayout, TypeOfBiome.GraveyardDifficult, "Cimetière des tontaton", 0.25);

            //zone de boss du cimetière
            mapLayout[36][401] = new Square { SquareBiome = bossGraveyard, Name = "Chef tontaton revenu", ChanceToTriggerFight = 1.0 };

            // ajout des différents villages
            mapLayout[152][82] = new Square { SquareBiome = village2, Name = "Logue Town", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            mapLayout[166][224] = new Square { SquareBiome = village3, Name = "Marine Ford", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };

            //ajout du village de départ astrub
            mapLayout[250][250] = new Square { SquareBiome = village, Name = "Astrub", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            //ajout du chateau du boss final du jeu
            mapLayout[246][250] = new Square { SquareBiome = bossVillage, Name = "Le chateau du grand Rico Chico", ChanceToTriggerFight = 1.0 };

            return mapLayout;
        }
    }
}
