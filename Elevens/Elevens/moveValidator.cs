public class MoveValidator
{
    public bool IsValidSelection(List<Card> selectedCards)
        {
            if (selectedCards.Count == 2)
            {
                return selectedCards[0].PointValue + selectedCards[1].PointValue == 11;
            }
            else if (selectedCards.Count == 3)
            {
                return selectedCards[0].Rank == "Jack" &&
                       selectedCards[1].Rank == "Queen" &&
                       selectedCards[2].Rank == "King";
            }
            else
            {
                return false;
            }
        }
}

