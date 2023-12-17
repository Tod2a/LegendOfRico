using System.Numerics;

namespace LegendOfRico.Data
{
    public class WoodFire: Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = false;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;

        //Récupération du constructeur
        public WoodFire(string name, string description, int price): base(name, description, price) { }

        //Définitaion de l'usage hors combat, permet au personnage et à son PartyMember de se reposer hors d'un village
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
