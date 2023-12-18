namespace LegendOfRico.Data
{
    public class Saving
    {
        public string CharactType { get; set; }

        public Saving()
        {
        }

        public Saving (Character player)
        {
            CharactType = GetStringType(player);
        }

        private string GetStringType(Character player)
        {
            if (player.GetType() == typeof(Rogue)) 
            {
                return "rogue";
            }
            else if (player.GetType() == typeof(Fighter))
            {
                return "fighter";
            }
            else if (player.GetType() == typeof(Ranger))
            {
                return "ranger";
            }
            else if (player.GetType() == typeof(Cleric))
            {
                return "cleric";
            }
            else
            {
                return "wizard";
            }
        }
    }
}
