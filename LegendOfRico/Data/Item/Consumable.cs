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
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;

        public virtual void Use(Game game)
        {
           if(Quantity > 0)
            {
                Quantity--;
            }
        }
    }
}
