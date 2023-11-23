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



        // tout ce qui suit sert à créer la map ainsi que son contenu

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

        //création des différents Biomes 3 par types pour les différentes images, un pour les cases dangereuses et un pour les boss
        //sauf pour le village et la plaine

        //Plaine
        public static Biomes plain = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine.png" };
        public static Biomes plain1 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine1.png" };
        public static Biomes plain2 = new Biomes { BiomeType = TypeOfBiome.Plain, MonsterPool = poolOfPlain, ImageUrl = "img/biomes/plaine2.png" };
        //forêt
        public static Biomes forest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret.png" };
        public static Biomes forest1 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret1.png" };
        public static Biomes forest2 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret2.png" };
        public static Biomes forest3 = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = poolOfForest, ImageUrl = "img/biomes/foret3.png" };
        public static Biomes bossForest = new Biomes { BiomeType = TypeOfBiome.Forest, MonsterPool = bossOfForest, ImageUrl = "img/biomes/foretBoss.png" };
        //désert
        public static Biomes desert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert.png" };
        public static Biomes desert1 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert1.png" };
        public static Biomes desert2 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert2.png" };
        public static Biomes desert3 = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = poolOfDesert, ImageUrl = "img/biomes/desert3.png" };
        public static Biomes bossDesert = new Biomes { BiomeType = TypeOfBiome.Desert, MonsterPool = bossOfDesert, ImageUrl = "img/biomes/desertBoss.png" };
        //ruines
        public static Biomes ruinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine.png" };
        public static Biomes ruinedVillage1 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine1.png" };
        public static Biomes ruinedVillage2 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine2.png" };
        public static Biomes ruinedVillage3 = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = poolOfRuined, ImageUrl = "img/biomes/ruine3.png" };
        public static Biomes bossRuinedVillage = new Biomes { BiomeType = TypeOfBiome.AbandonedVillage, MonsterPool = bossOfRuined, ImageUrl = "img/biomes/ruineBoss.png" };
        //cimetiere
        public static Biomes graveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere.png" };
        public static Biomes graveyard1 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere1.png" };
        public static Biomes graveyard2 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere2.png" };
        public static Biomes graveyard3 = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = poolOfGraveyard, ImageUrl = "img/biomes/cimetiere3.png" };
        public static Biomes bossGraveyard = new Biomes { BiomeType = TypeOfBiome.Graveyard, MonsterPool = bossOfGraveyard, ImageUrl = "img/biomes/cimetiereBoss.png" };
        //village
        public static Biomes village = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = poolOfVillage, ImageUrl = "img/biomes/village.png" };
        public static Biomes bossVillage = new Biomes { BiomeType = TypeOfBiome.Village, MonsterPool = bossOfVillage, ImageUrl = "img/biomes/villageBoss.png" };

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
                        mapLayout[i][j] = new Square {SquareBiome = plain2, Name = "Plaine tranquille", ChanceToTriggerFight = 0.05 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square {SquareBiome = plain, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.05 }; 
                    }
                    else
                    {
                        mapLayout[i][j] = new Square {SquareBiome = plain1, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.05 }; 
                    }
                }
            }



         

            //ajout d'une ruine au nord de la map

            for (int i = 0; i < 54; i++)
            {
                for (int j = 161; j < 201; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage2, Name = "Les ruines de raftool", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage, Name = "Les ruines de raftool", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage1, Name = "Les ruines de raftool", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            for (int i = 20; i < 32; i++)
            {
                for (int j = 187; j < 194; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = ruinedVillage3, Name = "Les ruines de raftool", ChanceToTriggerFight = 0.5 };
                }
            }

            //ajout une petite foret

            for (int i = 60; i < 110; i++)
            {
                for (int j = 234; j < 327; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Forêt de Nibel", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Forêt de Nibel", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Forêt de Nibel", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de cette forêt
            for (int i = 89; i < 101; i++)
            {
                for (int j = 249; j < 265; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = forest3, Name = "Forêt de Nibel", ChanceToTriggerFight = 0.5 };
                }
            }

            //ajout d'un désert
            for (int i = 165; i < 230; i++)
            {
                for (int j = 24; j < 74; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert2, Name = "Les milles et une boucles", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert, Name = "Les milles et une boucles", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert1, Name = "Les milles et une boucles", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de ce désert
            for (int i = 184; i < 198; i++)
            {
                for (int j = 43; j < 63; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = desert3, Name = "Les milles et une boucles", ChanceToTriggerFight = 0.5 };
                }
            }

            //ajout d'un cimetiere nord-ouest de la map
            for (int i = 154; i < 198; i++)
            {
                for (int j = 83; j < 180; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard2, Name = "Cimetière des héros", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard, Name = "Cimetière des héros", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard1, Name = "Cimetière des héros", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //une forêt
            for (int i = 243; i < 312; i++)
            {
                for (int j = 22; j < 110; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //un désert
            for (int i = 61; i < 165; i++)
            {
                for (int j = 157; j < 221; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert2, Name = "désert aride", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert, Name = "désert aride", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert1, Name = "désert aride", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //une ruine

            for (int i = 121; i < 201; i++)
            {
                for (int j = 231; j < 321; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage2, Name = "ruines de zilda", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage, Name = "ruines de zilda", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage1, Name = "ruines de zilda", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //une forêt
            for (int i = 154; i < 334; i++)
            {
                for (int j = 375; j < 465; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Forêt de Yasopp", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            // un cimetiere

            for (int i = 387; i < 487; i++)
            {
                for (int j = 178; j < 320; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard2, Name = "Cimetière sombre", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard, Name = "Cimetière sombre", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard1, Name = "Cimetière sombre", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //une forêt
            for (int i = 268; i < 324; i++)
            {
                for (int j = 275; j < 311; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Forêt d'elwyne", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Forêt d'elwyne", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Forêt d'elwyne", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            // un désert
            for (int i = 275; i < 323; i++)
            {
                for (int j = 175; j < 212; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert2, Name = "désert humide", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert, Name = "désert humide", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert1, Name = "désert humide", ChanceToTriggerFight = 0.1 };
                    }
                }
            }

            //création des 4 zones importantes du jeu, celles des 4 boss

            //création de la foret de Sherloop qui habrite un des 4 boss du jeu
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest2, Name = "Forêt de Sherloop", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest, Name = "Forêt de Sherloop", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = forest1, Name = "Forêt de Sherloop", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de cette forêt
            for (int i = 20; i < 80; i++)
            {
                for (int j = 10; j < 65; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = forest3, Name = "Forêt de Sherloop", ChanceToTriggerFight = 0.5 };
                }
            }
            //deuxieme zone dangereuse de cette forêt
            for (int i = 90; i < 110; i++)
            {
                for (int j = 110; j < 142; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = forest3, Name = "Forêt de Sherloop", ChanceToTriggerFight = 0.5 };
                }
            }
            //zone de boss de la forêt
            mapLayout[72][53] = new Square { SquareBiome = bossForest, Name = "Forêt de Sherloop", ChanceToTriggerFight = 1.0 };







            //création du désert Dune eternelle (référence à zelda et roi lion POG) qui habrite un des 4 boss du jeu
            for (int i = 349; i < 500; i++)
            {
                for (int j = 349; j < 500; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert2, Name = "La dune éternelle", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert, Name = "La dune éternelle", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = desert1, Name = "La dune éternelle", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de ce désert
            for (int i = 359; i < 372; i++)
            {
                for (int j = 352; j < 369; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = desert3, Name = "La dune éternelle", ChanceToTriggerFight = 0.5 };
                }
            }
            //deuxieme zone dangereuse de ce desert
            for (int i = 398; i < 431; i++)
            {
                for (int j = 354; j < 365; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = desert3, Name = "La dune éternelle", ChanceToTriggerFight = 0.5 };
                }
            }
            //troisieme zone dangereuse de ce desert
            for (int i = 357; i < 378; i++)
            {
                for (int j = 378; j < 403; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = desert3, Name = "La dune éternelle", ChanceToTriggerFight = 0.5 };
                }
            }
            //quatrieme zone dangereuse de ce desert
            for (int i = 469; i < 498; i++)
            {
                for (int j = 476; j < 496; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = desert3, Name = "La dune éternelle", ChanceToTriggerFight = 0.5 };
                }
            }
            //zone de boss de ce desert
            mapLayout[499][499] = new Square { SquareBiome = bossDesert, Name = "Le scorpion éternel", ChanceToTriggerFight = 1.0 };





            //création de l'ancienne cité de joy bean qui habrite un des 4 boss du jeu
            for (int i = 349; i < 500; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage2, Name = "l'ancienne cité de Joy Bean", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage, Name = "l'ancienne cité de Joy Bean", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = ruinedVillage1, Name = "l'ancienne cité de jJoy Bean", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de cette cité en ruine
            for (int i = 420; i < 468; i++)
            {
                for (int j = 56; j < 98; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = ruinedVillage3, Name = "l'ancienne cité de Joy Bean", ChanceToTriggerFight = 0.5 };
                }
            }
            //deuxieme zone dangereuse de cette cité en ruine
            for (int i = 357; i < 376; i++)
            {
                for (int j = 120; j < 135; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = ruinedVillage3, Name = "l'ancienne cité de Joy Bean", ChanceToTriggerFight = 0.5 };
                }
            }
            //zone de boss de cette cité en ruine
            mapLayout[428][58] = new Square { SquareBiome = bossRuinedVillage, Name = "Le grand Joy Bean", ChanceToTriggerFight = 1.0 };





            //création du Cimetière des tontaton qui habrite un des 4 boss du jeu
            for (int i = 0; i < 150; i++)
            {
                for (int j = 349; j < 500; j++)
                {
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard2, Name = "Cimetière des tontaton", ChanceToTriggerFight = 0.1 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard, Name = "Cimetière des tontaton", ChanceToTriggerFight = 0.1 };
                    }
                    else
                    {
                        mapLayout[i][j] = new Square { SquareBiome = graveyard1, Name = "Cimetière des tontaton", ChanceToTriggerFight = 0.1 };
                    }
                }
            }
            //zone dangereuse de ce cimetière
            for (int i = 20; i < 60; i++)
            {
                for (int j = 390; j < 435; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = graveyard3, Name = "Cimetière des tontaton", ChanceToTriggerFight = 0.5 };
                }
            }
            //deuxieme zone dangereuse de ce cimetiere
            for (int i = 90; i < 110; i++)
            {
                for (int j = 369; j < 385; j++)
                {
                    mapLayout[i][j] = new Square { SquareBiome = graveyard3, Name = "Cimetière des tontaton", ChanceToTriggerFight = 0.5 };
                }
            }
            //zone de boss du cimetière
            mapLayout[36][401] = new Square { SquareBiome = bossGraveyard, Name = "Chef tontaton revenu", ChanceToTriggerFight = 1.0 };

            // ajout des différents villages

            //ajout du village de départ astrub
            mapLayout[250][250] = new Square { SquareBiome = village, Name = "Astrub", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            //ajout du chateau du boss final du jeu
            mapLayout[246][250] = new Square { SquareBiome = bossVillage, Name = "Le chateau du grand Rico Chico", ChanceToTriggerFight = 1.0 };

            return mapLayout;
        }
    }
}
