public class Gameplay
{
    private readonly Random _random = new Random();
    public const int luckyNumber = 18;

    public void GameIteration( GameState gameState )
    {
        if ( !HasSufficientFunds( gameState ) )
            return;

        int bet = GetValidBet( gameState.Balance );
        int randomNum = GenerateRandomNumber();

        DisplayNumber( randomNum );
        ProcessResult( gameState, bet, randomNum );
    }

    private bool HasSufficientFunds( GameState gameState )
    {
        if ( gameState.Balance <= 0 )
        {
            Console.WriteLine( Messages.InsufficientFunds );
            return false;
        }
        return true;
    }

    private int GetValidBet( int maxBalance )
    {
        while ( true )
        {
            Console.Write( Messages.EnterBet );
            string input = Console.ReadLine() ?? string.Empty;

            if ( string.IsNullOrWhiteSpace( input ) )
            {
                Console.WriteLine( Messages.EmptyInput );
                continue;
            }

            if ( !int.TryParse( input, out int bet ) )
            {
                Console.WriteLine( Messages.InvalidNumber );
                continue;
            }

            if ( bet <= 0 )
            {
                Console.WriteLine( Messages.BetMustBePositive );
                continue;
            }

            if ( bet > maxBalance )
            {
                Console.WriteLine( string.Format( Messages.BetCannotExceedBalance, maxBalance ) );
                continue;
            }

            return bet;
        }
    }

    private int GenerateRandomNumber()
    {
        return _random.Next( 1, 21 );
    }

    private void DisplayNumber( int number )
    {
        Console.WriteLine( string.Format( Messages.NumberRolled, number ) );
    }

    private void ProcessResult( GameState gameState, int bet, int randomNum )
    {
        if ( randomNum >= luckyNumber )
        {
            int winAmount = CalculateWinAmount( bet, randomNum, gameState.Multiplex );
            gameState.Balance += winAmount;
            Console.WriteLine( string.Format( Messages.WinMessage, winAmount ) );
        }
        else
        {
            gameState.Balance -= bet;
            Console.WriteLine( string.Format( Messages.LoseMessage, bet ) );
        }
    }

    private int CalculateWinAmount( int bet, int randomNum, int multiplex )
    {
        return bet * ( 1 + multiplex * ( randomNum % 17 ) );
    }
}