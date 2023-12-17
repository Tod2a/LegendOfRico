namespace LegendOfRico.Data
{
    public class MagicWhistle: Consumable
    {
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedInFight { get; protected set; } = false;

        //Récupération du constructeur de base
        public MagicWhistle(string name, string description, int price) : base(name, description, price) { }

        //définition de l'utilisation hors combat, le personnage retourne à la positon du village de son dernier repos
        public override void Use(Character character)
        {
            base.Use(character);
            character.PositionI = character.lastRestVillageI;
            character.PositionJ = character.LastRestVillageJ;
        }
    }
}
