namespace LegendOfRico.Data
{
    public class TavernRecruits : NPC
    {
        public override string NPCName { get; protected set; } = "Taverne";
        public List<Character> CharactersToRecruit { get; private set; }

        public TavernRecruits()
        {
            CharactersToRecruit = new List<Character>
            {
                //Omega nitro sulfuro turbo giga NOOBS
                new Fighter
                {
                    Name = "Kévin",
                    RecruitingPrice = 1
                },
                new Wizard
                {
                    Name = "Killian",
                    RecruitingPrice = 1
                },
                new Rogue
                {
                    Name = "Dark Sasuke",
                    RecruitingPrice = 1
                },
                new Ranger
                {
                    Name = "Thomas",
                    RecruitingPrice = 1
                },
                new Cleric
                {
                    Name = "Patrick",
                    RecruitingPrice = 1
                },

                //Recrue débutante
                new Fighter
                {
                    Name = "Adam",
                    CharacterWeapon = new Greatsword("Espadon en bronze", "(5 - 8)", 50, 5, 8, 0),
                    CharacterShield = new FistShield("Poing", "Un poing", 0, 0),
                    CharacterArmor = new Armor("Armure en bronze", "Lourd | Armure : 4", 100, TypeOfArmor.Heavy, 4),
                    ArmorAmount = 4,
                    CanEquipShield = false,
                    RecruitingPrice = 150
                },
                new Wizard
                {
                    Name = "Leo",
                    CharacterWeapon = new Staff("Baton en frêne", "(1 - 5) | Stats +2", 50, 1, 5, 2),
                    CharacterArmor = new Armor("Armure en jute", "Léger | Armure : 2", 50, TypeOfArmor.Light, 2),
                    ArmorAmount = 2,
                    Statistics = 2,
                    RecruitingPrice = 150
                },
                new Rogue
                {
                    Name = "Antoine",
                    CharacterWeapon = new DoubleWeapon("Dague en bronze/Dague en bronze","(2 - 6)/(2 - 6)"
                        ,0,3,9,0,new Dagger("Dague en bronze", "(2 - 6)", 50, 3, 6, 0),new Dagger("Dague en bronze", "(2 - 6)", 50, 3, 6, 0)),
                    CharacterArmor = new Armor("Armure en cuir brute", "Moyen | Armure : 3", 75, TypeOfArmor.Medium, 3),
                    ArmorAmount = 3,
                    RecruitingPrice = 150
                },
                new Ranger
                {
                    Name = "Louis",
                    CharacterWeapon = new Bow("Arc en frêne", "(5 - 8)", 50, 5, 8, 0),
                    CharacterArmor = new Armor("Armure en cuir brute", "Moyen | Armure : 3", 75, TypeOfArmor.Medium, 3),
                    ArmorAmount = 3,
                    RecruitingPrice = 150
                },
                new Cleric
                {
                    Name = "Gabriel",
                    CharacterWeapon = new Mace("Masse en bronze", "(2 - 5)", 50, 2, 5, 0),
                    CharacterShield = new Shield("Bouclier en bronze", "Amure : 5", 50, 5),
                    CharacterArmor = new Armor("Armure en cuir brute", "Moyen | Armure : 3", 75, TypeOfArmor.Medium, 3),
                    ArmorAmount = 8,
                    RecruitingPrice = 150
                },

                //Recrue amatrice
                new Fighter
                {
                    Name = "Gérard",
                    CharacterWeapon = new Greatsword("Espadon en fer", "(10 - 16) | Stats +4", 100, 10, 16, 4),
                    CharacterShield = new FistShield("Poing", "Un poing", 0, 0),
                    CharacterArmor = new Armor("Armure en fer", "Lourd | Armure : 8", 250, TypeOfArmor.Heavy, 8),
                    ArmorAmount = 8,
                    CanEquipShield = false,
                    Statistics = 4,
                    RecruitingPrice = 400
                },
                new Wizard
                {
                    Name = "Didier",
                    CharacterWeapon = new Staff("Baton en noyer", "(1 - 5) | Stats +4", 100, 1, 5, 4),
                    CharacterArmor = new Armor("Armure en lin", "Léger | Armure : 4", 150, TypeOfArmor.Light, 4),
                    ArmorAmount = 4,
                    Statistics = 4,
                    RecruitingPrice = 400
                },
                new Rogue
                {
                    Name = "Jean",
                    CharacterWeapon = new DoubleWeapon("Dague en fer/Dague en fer","(4 - 12)/(4 - 12)",0,6,18,4,
                    new Dagger("Dague en fer", "(4 - 12) | Stats +2", 100, 4, 12, 2),new Dagger("Dague en fer", "(4 - 12) | Stats +2", 100, 4, 12, 2)),
                    CharacterArmor = new Armor("Armure en cuir fin", "Moyen | Armure : 6", 200, TypeOfArmor.Medium, 6),
                    ArmorAmount = 6,
                    Statistics = 2,
                    RecruitingPrice = 400
                },
                new Ranger
                {
                    Name = "Jerome",
                    CharacterWeapon = new Bow("Arc en noyer", "(10 - 16) | Stats +4", 100, 10, 16, 4),
                    CharacterArmor = new Armor("Armure en cuir fin", "Moyen | Armure : 6", 200, TypeOfArmor.Medium, 6),
                    ArmorAmount = 6,
                    Statistics = 4,
                    RecruitingPrice = 400,
                    Pet = new Americanstaff()
                },
                new Cleric
                {
                    Name = "Marc",
                    CharacterWeapon = new Mace("Masse en fer", "(4 - 10) | Stats +2", 100, 4, 10, 2),
                    CharacterShield = new Shield("Bouclier en fer", "Amure : 9", 100, 9),
                    CharacterArmor = new Armor("Armure en cuir fin", "Moyen | Armure : 6", 200, TypeOfArmor.Medium, 6),
                    ArmorAmount = 15,
                    Statistics = 2,
                    RecruitingPrice = 400
                },
                
                //Recrue compétente
                new Fighter
                {
                    Name = "Enzo",
                    CharacterWeapon = new Greatsword("Espadon en acier", "(20 - 32) | Stats +8", 200, 20, 32, 8),
                    CharacterShield = new FistShield("Poing", "Un poing", 0, 0),
                    CharacterArmor = new Armor("Armure en acier", "Lourd | Armure : 16", 650, TypeOfArmor.Heavy, 16),
                    ArmorAmount = 16,
                    CanEquipShield = false,
                    Statistics = 8,
                    RecruitingPrice = 850
                },
                new Wizard
                {
                    Name = "Isaac",
                    CharacterWeapon = new Staff("Baton en chêne", "(1 - 5) | Stats +8", 200, 1, 5, 8),
                    CharacterArmor = new Armor("Armure en coton", "Léger | Armure : 8", 450, TypeOfArmor.Light, 8),
                    ArmorAmount = 8,
                    Statistics = 8,
                    RecruitingPrice = 850
                },
                new Rogue
                {
                    Name = "Gaspard",
                    CharacterWeapon = new DoubleWeapon("Dague en acier/Dague en acier","(10 - 24)/(10 - 24)",0,15,36,8,
                    new Dagger("Dague en acier", "(10 - 24) | Stats +4", 200, 10, 24, 4),new Dagger("Dague en acier", "(10 - 24) | Stats +4", 200, 10, 24, 4)),
                    CharacterArmor = new Armor("Armure en cuir épais", "Moyen | Armure : 12", 550, TypeOfArmor.Medium, 12),
                    ArmorAmount = 12,
                    Statistics = 4,
                    RecruitingPrice = 850
                },
                new Ranger
                {
                    Name = "Sacha",
                    CharacterWeapon = new Bow("Arc en chêne", "(20 - 32) | Stats +8", 200, 20, 32, 8),
                    CharacterArmor = new Armor("Armure en cuir épais", "Moyen | Armure : 12", 550, TypeOfArmor.Medium, 12),
                    ArmorAmount = 12,
                    Statistics = 8,
                    RecruitingPrice = 850,
                    Pet = new Americanstaff()
                },
                new Cleric
                {
                    Name = "Ethan",
                    CharacterWeapon = new Mace("Masse en acier", "(8 - 20) | Stats +4", 200, 8, 20, 4),
                    CharacterShield = new Shield("Bouclier en acier", "Amure : 18", 250, 18),
                    CharacterArmor = new Armor("Armure en cuir épais", "Moyen | Armure : 12", 550, TypeOfArmor.Medium, 12),
                    ArmorAmount = 30,
                    Statistics = 4,
                    RecruitingPrice = 850
                },

                //Recrue experte
                new Fighter
                {
                    Name = "Varian",
                    CharacterWeapon = new Greatsword("Espadon en mithril", "(40 - 64) | Stats +16", 400, 40, 64, 16),
                    CharacterShield = new FistShield("Poing", "Un poing", 0, 0),
                    CharacterArmor = new Armor("Armure en mithril", "Lourd | Armure : 30", 1200, TypeOfArmor.Heavy, 30),
                    ArmorAmount = 30,
                    CanEquipShield = false,
                    Statistics = 16,
                    RecruitingPrice = 1250
                },
                new Wizard
                {
                    Name = "Antonidas",
                    CharacterWeapon = new Staff("Baton en orme", "(1 - 5) | Stats +16", 400, 1, 5, 16),
                    CharacterArmor = new Armor("Armure en soie", "Léger | Armure : 16", 800, TypeOfArmor.Light, 16),
                    ArmorAmount = 16,
                    Statistics = 16,
                    RecruitingPrice = 1250
                },
                new Rogue
                {
                    Name = "Martin",
                    CharacterWeapon = new DoubleWeapon("Dague en mithril/Dague en mithril","(20 - 50)/(20 - 50)",0,30,75,16,
                    new Dagger("Dague en mithril", "(20 - 50) | Stats +8", 400, 20, 50, 8),new Dagger("Dague en mithril", "(20 - 50) | Stats +8", 400, 20, 50, 8)),
                    CharacterArmor = new Armor("Armure en cuir travaillé", "Moyen | Armure : 22", 1000, TypeOfArmor.Medium, 22),
                    ArmorAmount = 22,
                    Statistics = 8,
                    RecruitingPrice = 1250
                },
                new Ranger
                {
                    Name = "Rexxar",
                    CharacterWeapon = new Bow("Arc en orme", "(40 - 64) | Stats +16", 400, 40, 64, 16),
                    CharacterArmor = new Armor("Armure en cuir travaillé", "Moyen | Armure : 22", 1000, TypeOfArmor.Medium, 22),
                    ArmorAmount = 22,
                    Statistics = 16,
                    RecruitingPrice = 1250,
                    Pet = new Rottweiler()
                },
                new Cleric
                {
                    Name = "Anduin",
                    CharacterWeapon = new Mace("Masse en mithril", "(16 - 40) | Stats +8", 400, 16, 40, 8),
                    CharacterShield = new Shield("Bouclier en mithril", "Amure : 35", 500, 35),
                    CharacterArmor = new Armor("Armure en cuir travaillé", "Moyen | Armure : 22", 1000, TypeOfArmor.Medium, 22),
                    ArmorAmount = 57,
                    Statistics = 8,
                    RecruitingPrice = 1250
                }
            };
        }
    }
}
