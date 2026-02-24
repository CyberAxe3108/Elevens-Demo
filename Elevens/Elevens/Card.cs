namespace Elevens;

public class Card
{
    public int Rank { get; }
    public Suit Suit{get;}
    
    
    public int ValueForEleven => Rank <= 10 ? Rank : 0; 
    public bool IsJack => Rank == 11;
    public bool IsQueen => Rank == 12;
    public bool IsKing => Rank == 13;

    public Card(int rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public override string ToString()
    {
        string rankStr = Rank switch
        {
            1 => "Ace",
            11 => "Jack",
            12 => "Queen",
            13 => "King",
            _ => Rank.ToString()
        };
        return $"{rankStr} of {Suit}";
    }
}
