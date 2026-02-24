namespace Elevens;

public class Table
{
    private List<Card> _visibleCards;

    public int MaxCards { get; } = 9;
    public IReadOnlyList<Card> Cards => _visibleCards.AsReadOnly();

    public Table()
    {
        _visibleCards = new List<Card>();
    }

    public int Count() => _visibleCards.Count;
    public bool IsEmpty() => _visibleCards.Count == 0;

    public void AddCard(Card card) => _visibleCards.Add(card);

    public Card GetCardAt(int index) => _visibleCards[index];

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
        => indices.Select(i => _visibleCards[i]).ToList();

    public void RemoveCards(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
            _visibleCards.Remove(card);
    }
}


