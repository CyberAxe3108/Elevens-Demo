using System.ComponentModel.DataAnnotations;

public class Deck {
    private List<Card> cards = new List<Card>();
    private Random random = new Random();
    public Deck()
    {
        for (int i = 0; i < Card.suits.Length; i++)
        {
            for (int j = 1; j < Card.values.Length; j++)
            {
                cards.Add(new Card(Card.values[j], Card.suits[i]));
            }
        }
    }
}
