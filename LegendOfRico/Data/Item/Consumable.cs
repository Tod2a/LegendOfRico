namespace LegendOfRico.Data
{
    public abstract class Consumable: Item
    {
        //Pour gérer la quantité et l'utilisation des consommables, ils doivent etre déclaré dans l'invetaire du personage
        //avec une quantité de 0
        //l'action Buy rajoutera 1 à la quatité dans le sac et l'affichage de chaque item ne se fera que si la quantité est supérieure à 1
        //attention, commencer par déclarer un nouveau consommable dans l'inventaire Character et l'id doit etre le numéro d'index 
        //dans l'inventaire de consommable
        // ensuite bien s'assurer que l'id est le même aux marchand
        public int Quantity { get; set; } = 0;
        public abstract bool CanBeUsedInFight { get; protected set; }
        public abstract bool CanBeUsedOutOfFight { get; protected set; }
        public virtual bool DodgeFight { get; protected set; } = false;

        public Consumable(string name, string description, int price) 
        {
            ItemName = name;
            Description = description;
            Price = price;
        }

        public virtual void Use(Character character)
        {
           if(Quantity > 0)
            {
                Quantity--;
            }
        }

        public virtual string UseInBattle(Character character)
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
            return "";
        }
    }
}
