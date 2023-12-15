namespace LegendOfRico.Data
{
    public class MagicWhistle: Consumable
    {
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedInFight { get; protected set; } = false;

        public MagicWhistle(string name, string description, int price) : base(name, description, price) { }

        public override void Use(Character character)
        {
            base.Use(character);
            character.PositionI = character.lastRestVillageI;
            character.PositionJ = character.LastRestVillageJ;
        }
    }
}
