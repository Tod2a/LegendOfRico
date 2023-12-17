using System.Xml.Linq;

namespace LegendOfRico.Data
{
    public class Potion : Consumable
    {
        public override bool CanBeUsedInFight { get; protected set; } = true;
        public override bool CanBeUsedOutOfFight { get; protected set; } = true;
        public override bool CanBeUsedOnMate { get; protected set; } = true;
        //ajout des paramètres de points de vie que la potion peut rendre
        public int MinHeal { get; } = 10;
        public int MaxHeal { get; } = 30;
        //création d'un dés de type random
        private readonly Random random = new Random();

        //Récupération du constructeur et ajout des paramètres nécessaires
        public Potion(string potionName, string description, int potionPrice, int minHeal, int maxHeal)
            : base(potionName, description, potionPrice)
        {
            MinHeal = minHeal;
            MaxHeal = maxHeal;
        }
        //Constructeur a 5 paramètres pour pouvoir ajouter 5 petites potions de base a un nouveau personnage
        public Potion(string potionName, string description, int potionPrice, int minHeal, int maxHeal, int quantity)
            : base(potionName,description, potionPrice) 
        {
            MinHeal = minHeal;
            MaxHeal = maxHeal;
            Quantity = quantity;
        }

        //Définitaion de l'usage hors combat cela soigne le Character mis en paramètre
        public override void Use(Character character) 
        {
            base.Use(character);
            int value = RollHealValue();
            character.ReceiveHeal(value);
        }

        //Définition de l'usage en combat retourne le string à afficher sur l'interface, cela soigne le Character mis en paramètre
        public override string UseInBattle(Character character)
        {
            base.UseInBattle(character);
            int value = RollHealValue();
            character.ReceiveHeal(value);
            return "La potion soigne " + character.Name + " de " + value + " points de vie,";
        }

        //Calcul du montant de heal de la potion
        public int RollHealValue() 
        {
            return (random.Next(MinHeal, MaxHeal + 1));
        }
    }
}
