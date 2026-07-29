public class GameState
{
    public int Balance { get; set; }
    public int Multiplex { get; set; } = 2;

    public GameState( int initialBalance )
    {
        Balance = initialBalance;
    }
}