namespace LegendOfRico.Data
{
    public class Coins : Item
    {
        public int quantity; // Quantity = cb de pièces (acheter qqch = Quantity - prix item)
        public Coins(int howManyCoins)
        {
            quantity = howManyCoins;
        }

        public void AddCoins(int howManyMoreCoins)
        {
            quantity += howManyMoreCoins;
        }

        public void LoseCoins(int howManyLostCoins)
        {
            quantity -= howManyLostCoins;
        }
    }
} // fait une propriété Coins dans Character plutôt, plus facile à manip, faudra surement supp cette classe