public class GameController
{
    private Deck deck;
    private Table table;

    public GameController()
    {
        deck = new Deck();
        table = new Table();
        table.CardsOnTable = deck.Deal(9);
    }

    public void DisplayTable()
    {
        Console.WriteLine("Cards on the table:");
        foreach (var card in table.CardsOnTable)
        {
            Console.WriteLine(card);
        }
    }
    public CheckEndState CheckForEndState()
    {
        if (CardsOnTable.Count == 0)
        {
            return CheckEndState.Win;
        }

        for (int i = 0; i < CardsOnTable.Count; i++)
        {
            for (int j = i + 1; j < CardsOnTable.Count; j++)
            {
                if (CardsOnTable[i].GetValue() + CardsOnTable[j].GetValue() == 11)
                {
                    return CheckEndState.Continue;
                }
            }
        }

        return CheckEndState.Lose;
    }
}