namespace LegendOfRico.Data
{
    public abstract class Consumable: Item
    {
        //Pour gérer la quantité et l'utilisation des consommables, ils doivent etre déclaré dans l'inventaire du personage
        //avec une quantité de 0
        //l'action Buy rajoutera 1 à la quatité dans le sac et l'affichage de chaque item ne se fera que si la quantité est supérieure à 1
        public int Quantity { get; set; } = 0;
        //Paramètres Bool qui donnent les permission d'utilisation des items
        public abstract bool CanBeUsedInFight { get; protected set; }
        public abstract bool CanBeUsedOutOfFight { get; protected set; }
        public virtual bool CanBeUsedOnMate { get; protected set; } = false;
        public virtual bool DodgeFight { get; protected set; } = false;

        //Constructeur de base des items consomables qui demande les 3 paramètres de base d'un item
        public Consumable(string name, string description, int price) 
        {
            ItemName = name;
            Description = description;
            Price = price;
        }

        //Fonction d'utilisation classique à redéfinir dans chaque item
        public virtual void Use(Character character)
        {
           if(Quantity > 0)
            {
                Quantity--;
            }
        }

        //Fonction d'utilisation en combats qui retourne le string necessaire à l'affichage sur l'interface de combat
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
