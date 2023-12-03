namespace LegendOfRico.Data
{
    public abstract class Consumable: Item
    {
        //Pour gérer la quantité et l'utilisation des consommables, ils doivent etre déclaré dans l'invetaire du personage
        //avec une quantité de 0
        //l'action Buy rajoutera 1 à la quatité dans le sac et l'affichage de chaque item ne se fera que si la quantité est supérieure à 1
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
