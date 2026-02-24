namespace Elevens;

public class Deck
{
    private List<Card> _cards;

    public int Count => _cards.Count;

    public Deck()
    {
        _cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            for (int rank = 1; rank <= 13; rank++)
                _cards.Add(new Card(rank, suit));
    }

    public bool IsEmpty() => _cards.Count == 0;

    public void Shuffle()
    {
        var rng = new Random();
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public Card DealCard()
    {
        if (IsEmpty()) throw new InvalidOperationException("Deck is empty.");
        var card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }
}

