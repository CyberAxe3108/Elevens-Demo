public class Card
{
   private int value;
   private string suit;
 
 public static string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
 public Card(int value, string suit)
 {
     this.value = value;
     this.suit = suit;
 }
    public int GetValue()
    {
        return value;
    }

    public override string ToString()
    {
        return $"{value} of {suit}";
    }
}