namespace Elevens.core;

public sealed class Deck {
    private readonly List<Card> cards = new();
    public int Count => cards.Count;

    public bool IsEmpty => cards.Count == 0;
    public Deck()
    {
        foreach (var suit in Card.suits)
        {
            for (int value = 1; value <= 13; value++)
            {
                cards.Add(new Card(value, suit));
            }
        }
        Shuffle();
    }
    public void Shuffle()
    {
        Random random = new Random();
        for (int i =cards.Count; i > 0; i--)
        {
            int j = random.Next(0, i +1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
 public Card DealCard()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("No cards left to deal.");
        }
        Card top = cards[Count - 1];
        cards.RemoveAt(Count - 1);
        return top;
    }
    
}
