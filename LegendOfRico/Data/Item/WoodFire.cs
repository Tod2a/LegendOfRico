using System.Numerics;

namespace LegendOfRico.Data
{
    public class WoodFire: Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = false;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;

        public WoodFire(string name, string description, int price): base(name, description, price) { }

        public override void Use(Character character)
        {
            base.Use(character);
            character.Rest();
            if (character.PartyMember != null)
            {
                character.PartyMember.Rest();
            }
        }
    }
}
