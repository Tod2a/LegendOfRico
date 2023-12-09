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
        
        public Map() { MapLayout = CreateMapLayout(); }

        //Fonction qui va changer les valeurs d'affichage de map à chaque déplacement
        public void UpdateMapDisplay(Character PersoTest)
        {
            StartI = PersoTest.PositionI - 4;
            MaxI = PersoTest.PositionI + 5;
            StartJ = PersoTest.PositionJ - 4;
            MaxJ = PersoTest.PositionJ + 5;
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
                            square.SquareBiome.MonsterPool = poolOfMediumPlain; 
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Forest || square.SquareBiome.BiomeType == TypeOfBiome.ForestDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfMediumForest;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Graveyard || square.SquareBiome.BiomeType == TypeOfBiome.GraveyardDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfMediumGraveyard;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Desert || square.SquareBiome.BiomeType == TypeOfBiome.DesertDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfMediumDesert;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillage || square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillageDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfMediumRuined;
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
                            square.SquareBiome.MonsterPool = poolOfHardPlain;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Forest || square.SquareBiome.BiomeType == TypeOfBiome.ForestDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfHardForest;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Graveyard || square.SquareBiome.BiomeType == TypeOfBiome.GraveyardDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfHardGraveyard;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.Desert || square.SquareBiome.BiomeType == TypeOfBiome.DesertDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfHardDesert;
                        }
                        else if (square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillage || square.SquareBiome.BiomeType == TypeOfBiome.AbandonedVillageDifficult)
                        {
                            square.SquareBiome.MonsterPool = poolOfHardRuined;
                        }
                    }
                }
            }
        }



        // tout ce qui suit sert à créer la map ainsi que son contenu
        // création des pool de monstres, 4 pools par biomes, trois en fonction du niveau de la map et un pour les boss
        //contenu des pool encore à définir mais divers pool déjà créés pour faire la map

        //plaine
        public List<Type> poolOfPlain = new List<Type> { typeof(Bulldog) };
        public List<Type> poolOfMediumPlain = new List<Type> { typeof(Americanstaff) };
        public List<Type> poolOfHardPlain = new List<Type> { typeof(Rottweiler) };
        //forêt
        public List<Type> poolOfForest = new List<Type> { typeof(SonOfAragog) };
        public List<Type> poolOfMediumForest = new List<Type> { typeof(BigSonOfAragog) };
        public List<Type> poolOfHardForest = new List<Type> { typeof(Aragog) };
        public List<Type> bossOfForest = new List<Type> { typeof(Sunwukong) };
        //désert
        public List<Type> poolOfDesert = new List<Type> { typeof(LittleFlame) };
        public List<Type> poolOfMediumDesert = new List<Type> { typeof(Flame) };
        public List<Type> poolOfHardDesert = new List<Type> { typeof(Volcanis) };
        public List<Type> bossOfDesert = new List<Type> { typeof(EternalScorpio) };
        //Ruines
        public List<Type> poolOfRuined = new List<Type> { typeof(Racaille), typeof(Nosptipti) };
        public List<Type> poolOfMediumRuined = new List<Type> { typeof(Gangster), typeof(Nosalto) };
        public List<Type> poolOfHardRuined = new List<Type> { typeof(Mafieux), typeof(Nosaffraid) };
        public List<Type> bossOfRuined = new List<Type> { typeof(JoyBean) };
        //cimetiere
        public List<Type> poolOfGraveyard = new List<Type> { typeof(Fantominet) };
        public List<Type> poolOfMediumGraveyard = new List<Type> { typeof(Spectre) };
        public List<Type> poolOfHardGraveyard = new List<Type> { typeof(Cauchemar) };
        public List<Type> bossOfGraveyard = new List<Type> { typeof(Cheftontaton) };
        //village
        public List<Type> poolOfVillage = new List<Type> {  };
        public List<Type> bossOfVillage = new List<Type> { typeof(RicoChico) };

        //création des différents Biomes 3 par types pour les différentes images, un pour les cases dangereuses et un pour les boss
        //sauf pour le village et la plaine

        //Plaine
        public Biomes plain => new Biomes(TypeOfBiome.Plain, poolOfPlain, "img/biomes/plaine.png", "img/layout/fondFightPlaine.png");
        public Biomes plain1 => new Biomes(TypeOfBiome.Plain, poolOfPlain, "img/biomes/plaine1.png", "img/layout/fondFightPlaine.png");
        public Biomes plain2 => new Biomes(TypeOfBiome.Plain, poolOfPlain, "img/biomes/plaine2.png", "img/layout/fondFightPlaine.png");
        //forêt
        public Biomes forest => new Biomes (TypeOfBiome.Forest,  poolOfForest, "img/biomes/foret.png", "img/layout/fondFightBois.png" );
        public Biomes forest1 => new Biomes (TypeOfBiome.Forest, poolOfForest, "img/biomes/foret1.png", "img/layout/fondFightBois.png");
        public Biomes forest2 => new Biomes (TypeOfBiome.Forest, poolOfForest, "img/biomes/foret2.png", "img/layout/fondFightBois.png");
        public Biomes forest3 => new Biomes (TypeOfBiome.ForestDifficult, poolOfForest, "img/biomes/foret3.png", "img/layout/fondFightBois.png");
        public Biomes bossForest => new Biomes (TypeOfBiome.Forest, bossOfForest, "img/biomes/foretBoss.png", "img/layout/fondFightBossBois.png");
        //désert
        public Biomes desert => new Biomes (TypeOfBiome.Desert, poolOfDesert, "img/biomes/desert.png", "img/layout/fondFightDesert.png");
        public Biomes desert1 => new Biomes (TypeOfBiome.Desert, poolOfDesert, "img/biomes/desert1.png", "img/layout/fondFightDesert.png");
        public Biomes desert2 => new Biomes (TypeOfBiome.Desert, poolOfDesert, "img/biomes/desert2.png", "img/layout/fondFightDesert.png");
        public Biomes desert3 => new Biomes (TypeOfBiome.DesertDifficult, poolOfDesert, "img/biomes/desert3.png", "img/layout/fondFightDesert.png");
        public Biomes desert4 => new Biomes (TypeOfBiome.DesertDifficult, poolOfDesert, "img/biomes/desert4.png", "img/layout/fondFightDesert.png");
        public Biomes desert5 => new Biomes (TypeOfBiome.DesertDifficult, poolOfDesert, "img/biomes/desert5.png", "img/layout/fondFightDesert.png");
        public Biomes bossDesert => new Biomes (TypeOfBiome.Desert, bossOfDesert, "img/biomes/desertBoss.png", "img/layout/fondFightBossDesert.png");
        //ruines
        public Biomes ruinedVillage => new Biomes (TypeOfBiome.AbandonedVillage, poolOfRuined, "img/biomes/ruine.png", "img/layout/fondFightRuine.png");
        public Biomes ruinedVillage1 => new Biomes (TypeOfBiome.AbandonedVillage, poolOfRuined, "img/biomes/ruine1.png", "img/layout/fondFightRuine.png");
        public Biomes ruinedVillage2 => new Biomes (TypeOfBiome.AbandonedVillage, poolOfRuined, "img/biomes/ruine2.png", "img/layout/fondFightRuine.png");
        public Biomes ruinedVillage3 => new Biomes (TypeOfBiome.AbandonedVillageDifficult, poolOfRuined, "img/biomes/ruine3.png", "img/layout/fondFightRuine.png");
        public Biomes bossRuinedVillage => new Biomes (TypeOfBiome.AbandonedVillage, bossOfRuined, "img/biomes/ruineBoss.png", "img/layout/fondFightBossRuine.png");
        //cimetiere
        public Biomes graveyard => new Biomes (TypeOfBiome.Graveyard, poolOfGraveyard, "img/biomes/cimetiere.png", "img/layout/fondFightCimetiere.png");
        public Biomes graveyard1 => new Biomes (TypeOfBiome.Graveyard, poolOfGraveyard, "img/biomes/cimetiere1.png", "img/layout/fondFightCimetiere.png");
        public Biomes graveyard2 => new Biomes (TypeOfBiome.Graveyard, poolOfGraveyard, "img/biomes/cimetiere2.png", "img/layout/fondFightCimetiere.png");
        public Biomes graveyard3 => new Biomes (TypeOfBiome.GraveyardDifficult, poolOfGraveyard, "img/biomes/cimetiere3.png", "img/layout/fondFightCimetiere.png");
        public Biomes bossGraveyard => new Biomes (TypeOfBiome.Graveyard, bossOfGraveyard, "img/biomes/cimetiereBoss.png", "img/layout/fondFightBossCimetiere.png");
        //village
        public Biomes village => new Biomes (TypeOfBiome.Village, poolOfVillage, "img/biomes/village.png", "img/layout/fondFightBossVillage.png");
        public Biomes village2 => new Biomes (TypeOfBiome.Village, poolOfVillage, "img/biomes/village2.png", "img/layout/fondFightBossVillage.png");
        public Biomes village3 => new Biomes (TypeOfBiome.Village, poolOfVillage, "img/biomes/village3.png", "img/layout/fondFightBossVillage.png");
        public Biomes village4 => new Biomes(TypeOfBiome.Village, poolOfVillage, "img/biomes/village4.png", "img/layout/fondFightBossVillage.png");
        public Biomes bossVillage => new Biomes(TypeOfBiome.Village, bossOfVillage, "img/biomes/villageBoss.png", "img/layout/fondFightBossVillage.png");


        private void TrippleSquare(int minI, int maxI, int minJ, int maxJ, Square[][] mapLayout, TypeOfBiome tBiome, string Name, double cTrigger)
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

        private Square[][] CreateMapLayout()
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

            //ajout du chateau du boss final du jeu
            mapLayout[246][250] = new Square { SquareBiome = bossVillage, Name = "Le chateau du grand Rico Chico", ChanceToTriggerFight = 1.0 };


            //creation des donneurs de quêtes et de leurs quêtes
            QuestGiver archibald = new QuestGiver("Archibald");
            archibald.AddFightQuest("Chasse une araignée", "Va dans la forêt chasser une araignée", TypeOfBreed.Spider, 20, 20);
            archibald.AddCollecQuest("Collectest", "Allez en 254 250", 20, 20, 254, 250, mapLayout[254][250].SquareBiome.BiomeType);
            archibald.AddFightQuest("Chasse un chien", "(CONSEILLÉ) Va dans les plaines et chasse un chien", TypeOfBreed.Dog, 950, 10);
            QuestGiver fatimaZorra = new QuestGiver("Fatima Zorra, la mystique");
            fatimaZorra.AddFightQuest("Tue un monstre", "Montre moi ton ENORME courage en allant tuer un monstre dans les ruines", TypeOfBreed.Bat, 20, 20);
            fatimaZorra.AddCollecQuest("Une beeeeellle récompense", "Un item se trouve dans les ruines, va le récupérer au péril de ta vie", 25, 25, 161, 281, mapLayout[161][281].SquareBiome.BiomeType);
            


            //ajout du village de départ astrub
            mapLayout[250][250] = new Square { SquareBiome = village, Name = "Astrub", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true, MisterQuest=archibald };

            // ajout des différents villages
            mapLayout[152][82] = new Square { SquareBiome = village2, Name = "Logue Town", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            mapLayout[166][224] = new Square { SquareBiome = village3, Name = "Marine Ford", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true };
            mapLayout[196][249] = new Square { SquareBiome = village4, Name = "Ancien Village", ChanceToTriggerFight = 0.0, HasNPC = true, HasQuestTarget = true, MisterQuest=fatimaZorra };
            

            
            

            return mapLayout;
        }
    }
}
