namespace Elevens;

public class GameController
{
    private readonly Deck _deck;
    private readonly Table _table;
    private readonly MoveValidator _validator;

    public GameState State { get; private set; }
    public Deck Deck => _deck;
    public Table Table => _table;

    public GameController(Deck? deck = null, Table? table = null, MoveValidator? validator = null)
    {
        _deck      = deck      ?? new Deck();
        _table     = table     ?? new Table();
        _validator = validator ?? new MoveValidator();
        State = GameState.NotStarted;
    }

    public void StartGame()
    {
        _deck.Shuffle();
        State = GameState.Running;
        RefillTableToNine();
        Console.WriteLine("[GameState] => Running");
    }

    public void RefillTableToNine()
    {
        while (_table.Count() < _table.MaxCards && !_deck.IsEmpty())
            _table.AddCard(_deck.DealCard());
    }

    public bool SubmitSelection(IReadOnlyList<int> indices, out string message)
    {
        var selected = _table.GetCardsByIndices(indices);

        if (!_validator.IsValidSelection(selected))
        {
            message = "Invalid selection. Try again.";
            return false;
        }

        _table.RemoveCards(selected);
        RefillTableToNine();
        CheckEndState();
        message = "Valid move!";
        return true;
    }

    public void CheckEndState()
    {
        if (CheckWin())
        {
            State = GameState.Won;
            Console.WriteLine("[GameState] => Won");
        }
        else if (CheckLose())
        {
            State = GameState.Lost;
            Console.WriteLine("[GameState] => Lost");
        }
        else
        {
            Console.WriteLine($"[GameState] => {State} | Cards on table: {_table.Count()} | Cards in deck: {_deck.Count}");
        }
    }

    public bool CheckWin()
        => _deck.IsEmpty() && _table.IsEmpty();

    public bool CheckLose()
        => !CheckWin() && _deck.IsEmpty() && !_validator.HasLegalMoves(_table.Cards);
}
