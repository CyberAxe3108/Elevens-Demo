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
    private void Shuffle()
    {
        int n = cards.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
 public List<Card> Deal(int numberOfCards)
    {
        Shuffle();

        numberOfCards = Math.Min(numberOfCards, 9);

        List<Card> hand = new List<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            if (cards.Count > 0)
            {
                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }
        }

        return hand;
    }

    public int CardsRemaining()
    {
        return cards.Count;
    }
}
