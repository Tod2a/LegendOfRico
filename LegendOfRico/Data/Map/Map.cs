using System.Collections.Specialized;

namespace LegendOfRico.Data
{
    public class Map
    {
        public Square[][] MapLayout { get; }
        //4 Variables necessaire à l'affichage de la map
        public int StartI { get; set; }
        public int MaxI { get; set; }
        public int StartJ { get; set; }
        public int MaxJ { get; set; }
        private int mapLevel = 1;
        public int MapLevel 
        {
            get {return mapLevel; }
            set 
            {
                if(mapLevel != value)
                {
                    mapLevel = value;
                    CheckPoolOfMonster();
                }
            } 
        }
        
        public Map() { 
            Plain = new Biomes(TypeOfBiome.Plain, PoolOfPlain, "img/biomes/plaine.png", "img/layout/fondFightPlaine.png");
            Plain1 = new Biomes(TypeOfBiome.Plain, PoolOfPlain, "img/biomes/plaine1.png", "img/layout/fondFightPlaine.png");
            Plain2 = new Biomes(TypeOfBiome.Plain, PoolOfPlain, "img/biomes/plaine2.png", "img/layout/fondFightPlaine.png");

            Forest = new Biomes(TypeOfBiome.Forest, PoolOfForest, "img/biomes/foret.png", "img/layout/fondFightBois.png");
            Forest1 = new Biomes(TypeOfBiome.Forest, PoolOfForest, "img/biomes/foret1.png", "img/layout/fondFightBois.png");
            Forest2 = new Biomes(TypeOfBiome.Forest, PoolOfForest, "img/biomes/foret2.png", "img/layout/fondFightBois.png");
            Forest3 = new Biomes(TypeOfBiome.ForestDifficult, PoolOfForest, "img/biomes/foret3.png", "img/layout/fondFightBois.png");
            BossForest = new Biomes(TypeOfBiome.ForestBoss, BossOfForest, "img/biomes/foretBoss.png", "img/layout/fondFightBossBois.png");

            Desert = new Biomes(TypeOfBiome.Desert, PoolOfDesert, "img/biomes/desert.png", "img/layout/fondFightDesert.png");
            Desert1 = new Biomes(TypeOfBiome.Desert, PoolOfDesert, "img/biomes/desert1.png", "img/layout/fondFightDesert.png");
            Desert2 = new Biomes(TypeOfBiome.Desert, PoolOfDesert, "img/biomes/desert2.png", "img/layout/fondFightDesert.png");
            Desert3 = new Biomes(TypeOfBiome.DesertDifficult, PoolOfDesert, "img/biomes/desert3.png", "img/layout/fondFightDesert.png");
            Desert4 = new Biomes(TypeOfBiome.DesertDifficult, PoolOfDesert, "img/biomes/desert4.png", "img/layout/fondFightDesert.png");
            Desert5 = new Biomes(TypeOfBiome.DesertDifficult, PoolOfDesert, "img/biomes/desert5.png", "img/layout/fondFightDesert.png");
            BossDesert = new Biomes(TypeOfBiome.DesertBoss, BossOfDesert, "img/biomes/desertBoss.png", "img/layout/fondFightBossDesert.png");

            RuinedVillage = new Biomes(TypeOfBiome.AbandonedVillage, PoolOfRuined, "img/biomes/ruine.png", "img/layout/fondFightRuine.png");
            RuinedVillage1 = new Biomes(TypeOfBiome.AbandonedVillage, PoolOfRuined, "img/biomes/ruine1.png", "img/layout/fondFightRuine.png");
            RuinedVillage2 = new Biomes(TypeOfBiome.AbandonedVillage, PoolOfRuined, "img/biomes/ruine2.png", "img/layout/fondFightRuine.png");
            RuinedVillage3 = new Biomes(TypeOfBiome.AbandonedVillageDifficult, PoolOfRuined, "img/biomes/ruine3.png", "img/layout/fondFightRuine.png");
            BossRuinedVillage = new Biomes(TypeOfBiome.AbandonedVillageBoss, BossOfRuined, "img/biomes/ruineBoss.png", "img/layout/fondFightBossRuine.png");

            Graveyard = new Biomes(TypeOfBiome.Graveyard, PoolOfGraveyard, "img/biomes/cimetiere.png", "img/layout/fondFightCimetiere.png");
            Graveyard1 = new Biomes(TypeOfBiome.Graveyard, PoolOfGraveyard, "img/biomes/cimetiere1.png", "img/layout/fondFightCimetiere.png");
            Graveyard2 = new Biomes(TypeOfBiome.Graveyard, PoolOfGraveyard, "img/biomes/cimetiere2.png", "img/layout/fondFightCimetiere.png");
            Graveyard3 = new Biomes(TypeOfBiome.GraveyardDifficult, PoolOfGraveyard, "img/biomes/cimetiere3.png", "img/layout/fondFightCimetiere.png");
            BossGraveyard = new Biomes(TypeOfBiome.GraveyardBoss, BossOfGraveyard, "img/biomes/cimetiereBoss.png", "img/layout/fondFightBossCimetiere.png");

            Village = new Biomes(TypeOfBiome.Village, PoolOfVillage, "img/biomes/village.png", "img/layout/fondFightBossVillage.png");
            Village2 = new Biomes(TypeOfBiome.Village, PoolOfVillage, "img/biomes/village2.png", "img/layout/fondFightBossVillage.png");
            Village3 = new Biomes(TypeOfBiome.Village, PoolOfVillage, "img/biomes/village3.png", "img/layout/fondFightBossVillage.png");
            Village4 = new Biomes(TypeOfBiome.Village, PoolOfVillage, "img/biomes/village4.png", "img/layout/fondFightBossVillage.png");
            BossVillage = new Biomes(TypeOfBiome.VillageBoss, BossOfVillage, "img/biomes/villageBoss.png", "img/layout/fondFightBossVillage.png");

            MapLayout = CreateMapLayout(); 
        }

        //Fonction qui va changer les valeurs d'affichage de map à chaque déplacement
        public void UpdateMapDisplay(Character player)
        {
            StartI = player.PositionI - 4;
            MaxI = player.PositionI + 5;
            StartJ = player.PositionJ - 4;
            MaxJ = player.PositionJ + 5;
            if (StartI < 0) { StartI = 0; }
            if (StartJ < 0) { StartJ = 0; }
            if (MaxI > 500) { MaxI = 500; }
            if (MaxJ > 500) { MaxJ = 500; }
        }

        //Fonction pour ajuster le pool de monstre en cas de lvl up de la carte
        private void CheckPoolOfMonster()
        {
            if(MapLevel == 5)
            {
                foreach(var lines in MapLayout)
                {
                    foreach(var square in lines)
                    {
                        if (square.SquareBiome.BiomeType == TypeOfBiome.Plain)
                        { 
                            square.SquareBiome.MonsterPool = PoolOfMediumPlain; 
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Forest || square.SquareBiome.BiomeType == TypeOfBiome.ForestDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfMediumForest;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Graveyard || square.SquareBiome.BiomeType == TypeOfBiome.GraveyardDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfMediumGraveyard;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Desert || square.SquareBiome.BiomeType == TypeOfBiome.DesertDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfMediumDesert;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillage || square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillageDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfMediumRuined;
                        }                
                    }
                }
            }
            if (MapLevel == 10)
            {
                foreach (var lines in MapLayout)
                {
                    foreach (var square in lines)
                    {
                        if (square.SquareBiome.BiomeType == TypeOfBiome.Plain)
                        {
                            square.SquareBiome.MonsterPool = PoolOfHardPlain;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Forest || square.SquareBiome.BiomeType == TypeOfBiome.ForestDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfHardForest;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Graveyard || square.SquareBiome.BiomeType == TypeOfBiome.GraveyardDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfHardGraveyard;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Desert || square.SquareBiome.BiomeType == TypeOfBiome.DesertDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfHardDesert;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillage || square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillageDifficult)
                        {
                            square.SquareBiome.MonsterPool = PoolOfHardRuined;
                        }
                    }
                }
            }
        }



        // tout ce qui suit sert à créer la map ainsi que son contenu
        // création des pool de monstres, 4 pools par biomes, trois en fonction du niveau de la map et un pour les boss
        //contenu des pool encore à définir mais divers pool déjà créés pour faire la map

        //plaine
        public List<Monster> PoolOfPlain { get; private set; } = new List<Monster> {  new Bulldog() };
        public List<Monster> PoolOfMediumPlain { get; private set; } = new List<Monster> { new Americanstaff() };
        public List<Monster> PoolOfHardPlain { get; private set; } = new List<Monster> { new Rottweiler() };
        //forêt
        public List<Monster> PoolOfForest { get; private set; } = new List<Monster> { new SonOfAragog(), new OmegaWolf() };
        public List<Monster> PoolOfMediumForest { get; private set; } = new List<Monster> { new BigSonOfAragog() };
        public List<Monster> PoolOfHardForest { get; private set; } = new List<Monster> { new Aragog() };
        public List<Monster> BossOfForest { get; private set; } = new List<Monster> { new Sunwukong() };
        //désert
        public List<Monster> PoolOfDesert { get; private set; } = new List<Monster> { new LittleFlame(), new LittleScorpio() };
        public List<Monster> PoolOfMediumDesert { get; private set; } = new List<Monster> { new Flame() };
        public List<Monster> PoolOfHardDesert { get; private set; } = new List<Monster> { new Volcanis() };
        public List<Monster> BossOfDesert { get; private set; } = new List<Monster> { new EternalScorpio() };
        //Ruines
        public List<Monster> PoolOfRuined { get; private set; } = new List<Monster> { new Racaille(), new Nosptipti(), new FlashOfLighting() };
        public List<Monster> PoolOfMediumRuined { get; private set; } = new List<Monster> { new Gangster(), new Nosalto(), new Thunderstorm() };
        public List<Monster> PoolOfHardRuined { get; private set; } = new List<Monster> { new Mafieux(), new Nosaffraid(), new Ener() };
        public List<Monster> BossOfRuined { get; private set; } = new List<Monster> { new JoyBean() };
        //cimetiere
        public List<Monster> PoolOfGraveyard { get; private set; } = new List<Monster> { new Fantominet(), new IceCube() };
        public List<Monster> PoolOfMediumGraveyard { get; private set; } = new List<Monster> { new Spectre(), new IceBlock() };
        public List<Monster> PoolOfHardGraveyard { get; private set; } = new List<Monster> { new Cauchemar(), new Iceberg() };
        public List<Monster> BossOfGraveyard { get; private set; } = new List<Monster> { new Cheftontaton() };
        //village
        public List<Monster> PoolOfVillage { get; private set; } = new List<Monster> {  };
        public List<Monster> BossOfVillage { get; private set; } = new List<Monster> { new RicoChico() };

        //création des différents Biomes 3 par types pour les différentes images, un pour les cases dangereuses et un pour les boss
        //sauf pour le village et la plaine

        //Plaine
        public Biomes Plain { get; private set; } 
        public Biomes Plain1 { get; private set; }
        public Biomes Plain2 { get; private set; }
        //forêt
        public Biomes Forest {get; private set;}
        public Biomes Forest1 { get; private set;}
        public Biomes Forest2 {get; private set;}
        public Biomes Forest3 { get; private set; }
        public Biomes BossForest { get; private set; }
        //désert
        public Biomes Desert { get; private set; }
        public Biomes Desert1 { get; private set; }
        public Biomes Desert2 { get; private set; }
        public Biomes Desert3 { get; private set; }
        public Biomes Desert4 { get; private set; }
        public Biomes Desert5 { get; private set; }
        public Biomes BossDesert { get; private set; }
        //ruines
        public Biomes RuinedVillage { get; private set; }
        public Biomes RuinedVillage1 { get; private set; }
        public Biomes RuinedVillage2 { get; private set; }
        public Biomes RuinedVillage3 { get; private set; }
        public Biomes BossRuinedVillage { get; private set; }
        //cimetiere
        public Biomes Graveyard { get; private set; }
        public Biomes Graveyard1 {  get; private set; }
        public Biomes Graveyard2 {  get; private set; }
        public Biomes Graveyard3 { get; private set; }
        public Biomes BossGraveyard { get; private set; }
        //village
        public Biomes Village { get; private set; }
        public Biomes Village2 { get; private set; }
        public Biomes Village3 {get; private set; }
        public Biomes Village4 {  get; private set; }
        public Biomes BossVillage { get; private set; }


        //Fonction qui automatise la création de zone sur la carte, demande les coordonnées, le type de biome, un nom de zone et les chance de combats
        private void TrippleSquare(int minI, int maxI, int minJ, int maxJ, Square[][] mapLayout, TypeOfBiome tBiome, string Name, double cTrigger)
        {
            Biomes b0 = Plain;
            Biomes b1 = Plain1;
            Biomes b2 = Plain2;

            switch (tBiome)
            {
                case TypeOfBiome.Forest:
                    b0 = Forest;
                    b1 = Forest1;
                    b2 = Forest2;
                    break;
                case TypeOfBiome.AbandonedVillage:
                    b0 = RuinedVillage;
                    b1 = RuinedVillage1;
                    b2 = RuinedVillage2;
                    break;
                case TypeOfBiome.Desert:
                    b0 = Desert;
                    b1 = Desert1;
                    b2 = Desert2;
                    break;
                case TypeOfBiome.Graveyard:
                    b0 = Graveyard;
                    b1 = Graveyard1;
                    b2 = Graveyard2;
                    break;
                case TypeOfBiome.DesertDifficult:
                    b0 = Desert3;
                    b1 = Desert4;
                    b2 = Desert5;
                    break;
                case TypeOfBiome.GraveyardDifficult:
                    b0 = Graveyard3;
                    b1 = Graveyard3;
                    b2 = Graveyard3;
                    break;
                case TypeOfBiome.AbandonedVillageDifficult:
                    b0 = RuinedVillage3;
                    b1 = RuinedVillage3;
                    b2 = RuinedVillage3;
                    break;
                case TypeOfBiome.ForestDifficult:
                    b0 = Forest3;
                    b1 = Forest3;
                    b2 = Forest3;
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

        private Square[][] CreateMapLayout()
        {
            Square[][] mapLayout = new Square[500][];
            // création de la map de base remplie de plaines
            for (int i = 0; i < 500; i++)
            {
                mapLayout[i] = new Square[500];

                for (int j = 0; j < 500; j++)
                {
                    //utilisation des 3 images différentes en fonction du modulo des coordonées de chaque square
                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        mapLayout[i][j] = new Square {SquareBiome = Plain2, Name = "Plaine tranquille", ChanceToTriggerFight = 0.025 };
                    }
                    else if (j % 3 == 0 && i % 4 == 0)
                    {
                        mapLayout[i][j] = new Square {SquareBiome = Plain, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.025 }; 
                    }
                    else
                    {
                        mapLayout[i][j] = new Square {SquareBiome = Plain1, Name = "Plaine Tranquille", ChanceToTriggerFight = 0.025 }; 
                    }
                }
            }



            //ajout d'une ruine au nord de la map

            TrippleSquare(0, 54, 161, 201, mapLayout, TypeOfBiome.AbandonedVillage, "Les ruines de Raftool", 0.1);
            TrippleSquare(20, 32, 187, 194, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "Les ruines de Raftool", 0.2);

            //ajout foret
            TrippleSquare(60, 110, 234, 327, mapLayout, TypeOfBiome.Forest, "Forêt de Nibel", 0.1);
            TrippleSquare(89, 101, 249, 265, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Nibel", 0.2);

            //ajout d'un désert

            TrippleSquare(165, 230, 24, 74, mapLayout, TypeOfBiome.Desert, "Les milles et une boucles", 0.1);
            TrippleSquare(184, 198, 43, 63, mapLayout, TypeOfBiome.DesertDifficult, "Les milles et une boucles", 0.2);

            //ajout d'un cimetiere nord-ouest de la map
            TrippleSquare(154, 198, 83, 180, mapLayout, TypeOfBiome.Graveyard, "Cimetière des héros", 0.1);

            //une forêt
            TrippleSquare(243, 312, 22, 110, mapLayout, TypeOfBiome.Forest, "Forêt de Yasopp", 0.1);

            //un désert
            TrippleSquare(61, 165, 157, 221, mapLayout, TypeOfBiome.Desert, "Désert aride", 0.1);

            //une ruine
            TrippleSquare(121, 201, 231, 321, mapLayout, TypeOfBiome.AbandonedVillage, "Ruines de Zilda", 0.1);

            //une forêt
            TrippleSquare(154, 334, 375, 465, mapLayout, TypeOfBiome.Forest, "Forêt de Yasopp", 0.1);

            // un cimetiere
            TrippleSquare(387, 487, 178, 320, mapLayout, TypeOfBiome.Graveyard, "Cimetière sombre", 0.1);

            //une forêt
            TrippleSquare(268, 324, 275, 311, mapLayout, TypeOfBiome.Forest, "Forêt d'Elwyne", 0.1);

            // un désert
            TrippleSquare(275, 323, 175, 212, mapLayout, TypeOfBiome.Desert, "Désert humide", 0.1);

            
           
            //création des 4 zones importantes du jeu, celles des 4 boss

            //création de la foret de Sherloop qui habrite un des 4 boss du jeu
            TrippleSquare(0, 150, 0, 150, mapLayout, TypeOfBiome.Forest, "Forêt de sherloop", 0.1);

            //zone dangereuse de cette forêt
            TrippleSquare(20, 80, 10, 65, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Sherloop", 0.2);

            //deuxieme zone dangereuse de cette forêt
            TrippleSquare(90, 110, 110, 142, mapLayout, TypeOfBiome.ForestDifficult, "Forêt de Sherloop", 0.2);

            //zone de boss de la forêt
            mapLayout[72][53] = new Square { SquareBiome = BossForest, Name = "Sun Wukong", ChanceToTriggerFight = 1.0 };

           

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
            mapLayout[499][499] = new Square { SquareBiome = BossDesert, Name = "Le scorpion éternel", ChanceToTriggerFight = 1.0 };



            //création de l'ancienne cité de joy bean qui habrite un des 4 boss du jeu
            TrippleSquare(349, 500, 0, 150, mapLayout, TypeOfBiome.AbandonedVillage, "l'ancienne cité de Joy Bean", 0.1);

            //zone dangereuse de cette cité en ruine
            TrippleSquare(420, 468, 56, 98, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "l'ancienne cité de Joy Bean", 0.2);

            //deuxieme zone dangereuse de cette cité en ruine
            TrippleSquare(357, 376, 120, 135, mapLayout, TypeOfBiome.AbandonedVillageDifficult, "l'ancienne cité de Joy Bean", 0.2);

            //zone de boss de cette cité en ruine
            mapLayout[428][58] = new Square { SquareBiome = BossRuinedVillage, Name = "Le grand Joy Bean", ChanceToTriggerFight = 1.0 };



            //création du Cimetière des tontaton qui habrite un des 4 boss du jeu
            TrippleSquare(0, 150, 349, 500, mapLayout, TypeOfBiome.Graveyard, "Cimetière des tontaton", 0.1);

            //zone dangereuse de ce cimetière
            TrippleSquare(20, 60, 390, 435, mapLayout, TypeOfBiome.GraveyardDifficult, "Cimetière des tontaton", 0.2);

            //deuxieme zone dangereuse de ce cimetiere
            TrippleSquare(90, 110, 369, 385, mapLayout, TypeOfBiome.GraveyardDifficult, "Cimetière des tontaton", 0.2);

            //zone de boss du cimetière
            mapLayout[36][401] = new Square { SquareBiome = BossGraveyard, Name = "Chef tontaton revenu", ChanceToTriggerFight = 1.0 };

            //ajout du chateau du boss final du jeu
            mapLayout[246][250] = new Square { SquareBiome = BossVillage, Name = "Le chateau du grand Rico Chico", ChanceToTriggerFight = 1.0 };


            //creation des donneurs de quêtes et de leurs quêtes
            QuestGiver archibald = new QuestGiver("Archibald");
            archibald.AddFightQuest("Chasse une araignée", "Va dans la forêt chasser une araignée", TypeOfBreed.Spider, 20, 20);
            archibald.AddCollecQuest("CollecDemo", "Quête de collecte pour la démo", 20, 20, 254, 250, mapLayout[254][250].SquareBiome.BiomeType);
            archibald.AddFightQuest("Chasse un chien", "(CONSEILLÉ) Va dans les plaines et chasse un chien", TypeOfBreed.Dog, 950, 10);
            QuestGiver fatimaZorra = new QuestGiver("Fatima Zorra, la mystique");
            fatimaZorra.AddFightQuest("Tue un monstre", "Montre moi ton ENORME courage en allant tuer un monstre dans les ruines", TypeOfBreed.Bat, 20, 20);
            fatimaZorra.AddCollecQuest("Une beeeeellle récompense", "Un item se trouve dans les ruines, va le récupérer au péril de ta vie", 25, 25, 161, 281, mapLayout[161][281].SquareBiome.BiomeType);
            fatimaZorra.AddCollecQuest("DemoCollectQuest", "Demo Quest", 5, 5, 196, 251, mapLayout[196][251].SquareBiome.BiomeType);
            


            //ajout du village de départ astrub
            mapLayout[250][250] = new Square { SquareBiome = Village, Name = "Astrub", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true, MisterQuest=archibald };

            // ajout des différents villages
            mapLayout[152][82] = new Square { SquareBiome = Village2, Name = "Logue Town", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            mapLayout[166][224] = new Square { SquareBiome = Village3, Name = "Marine Ford", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            mapLayout[196][249] = new Square { SquareBiome = Village4, Name = "Ancien Village", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true, MisterQuest=fatimaZorra };
            

            
            

            return mapLayout;
        }
    }
}
