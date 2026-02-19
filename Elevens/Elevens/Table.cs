namespace Elevens.core;

public sealed class Table
{
    private readonly List<Card> CardsOnTable = new();
    
    public int maxCards {get;}
    public IReadOnlyList<Card> Cards => CardsOnTable;
    public Table(int maxCards = 9)
    {
        if (maxCards <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxCards));
        MaxCards = maxCards;
        }
    }

    public int Count => CardsOnTable.Count;
    
    public bool isEmpty => CardsOnTable.Count == 0;

    public void AddCard(Card card)
    {
        if (CardsOnTable.Count >= MaxCards)
        {
            throw new InvalidOperationException("Table is full.");
        }
        CardsOnTable.Add(card);
    }

    public GetCard(int index)
    {
        if (index < 0 || index >= CardsOnTable.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return CardsOnTable[index];
    }

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
    {
        List<Card> selectedCards = new();
        foreach (int index in indices)
        {
            if (index < 0 || index >= CardsOnTable.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(indices));
            }
            selectedCards.Add(CardsOnTable[index]);
        }
        return selectedCards;
    }

    public void RemoveCards(IEnumerable<Card> cards)
    {
        foreach (var c in cards)
        {
            int removed = CardsOnTable.Remove(c);
            if (!removed){
                throw new InvalidOperationException("Card not found on the table.");
            }
        }
    }

}
