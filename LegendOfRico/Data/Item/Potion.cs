using System.Xml.Linq;

namespace LegendOfRico.Data
{
    public class Potion : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedOnMate { get; protected set; } = true;
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;
        private readonly Random random = new Random();


        public Potion(string potionName, string description, int potionPrice, int minHeal, int maxHeal, int quantity)
            : base(potionName,description, potionPrice) 
        {
            MinHeal = minHeal;
            MaxHeal = maxHeal;
            Quantity = quantity;
        }

        public override void Use(Character character) 
        {
            base.Use(character);
            int value = RollHealValue();
            character.CurrentHitPoints += value;
            if (character.CurrentHitPoints > character.MaxHitPoints)
            {
                character.CurrentHitPoints = character.MaxHitPoints;
            }
        }

        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            int value = RollHealValue();
            character.CurrentHitPoints += value;
            if (character.CurrentHitPoints > character.MaxHitPoints)
            {
                character.CurrentHitPoints = character.MaxHitPoints;
            }
            return "La potion soigne " + character.Name + " de " + value + " points de vie,";
        }
        public int RollHealValue() 
        {
            return (random.Next(MinHeal, MaxHeal + 1));
        }
    }
}
