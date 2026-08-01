public class GameState
{
    public int Balance { get; private set; }
    public const int multiplex = 2;

    public GameState( int initialBalance )
    {
        if ( initialBalance < 0 )
        {
            throw new ArgumentException( Messages.NegativeInitialBalance );
        }

        Balance = initialBalance;
    }

    public void AddWinnings( int amount )
    {
        if ( amount < 0 )
        {
            throw new ArgumentException( Messages.NegativeWinAmount );
        }

        Balance += amount;
    }

    public bool DeductBet( int amount )
    {
        if ( amount < 0 )
        {
            throw new ArgumentException( Messages.NegativeBetAmount );
        }

        if ( amount > Balance )
        {
            Console.WriteLine( string.Format( Messages.InsufficientFundsForBet, Balance, amount ) );
            return false;
        }

        Balance -= amount;
        return true;
    }

    public bool HasSufficientFunds( int amount )
    {
        return Balance > 0 && amount <= Balance;
    }
}
