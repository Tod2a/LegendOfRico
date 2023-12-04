namespace LegendOfRico.Data
{
    public class Potion : Consumable
    {
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;
       


        public Potion(int id, string potionName, int potionPrice, int minHeal, int maxHeal)
        {
            Id = id;
            ItemName = potionName;
            Price = potionPrice;
            MinHeal = minHeal;
            MaxHeal = maxHeal;
        }

        public Potion(int id, string potionName, int potionPrice, int minHeal, int maxHeal, int quantity)
        {
            Id = id;
            ItemName = potionName;
            Price = potionPrice;
            MinHeal = minHeal;
            MaxHeal = maxHeal;
            Quantity = quantity;
        }

        public override void Use(Game game) 
        {
            base.Use(game);
            int value = RollHealValue();
            game.Player.CurrentHitPoints += value;
            if (game.Player.CurrentHitPoints > game.Player.MaxHitPoints)
            {
                game.Player.CurrentHitPoints = game.Player.MaxHitPoints;
            }
            game.FightMessage = "Vous vous soignez de " + value + " points de vie,";
            game.MonsterHit(game);
        }

        public int RollHealValue() 
        {
            return (new Random()).Next(MinHeal, MaxHeal + 1);
        }
    }
}
