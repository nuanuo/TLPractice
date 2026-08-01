public class Gameplay
{
    public const int luckyNumberMin = 18;
    public const int luckyNumberMax = 20;

    public void GameIteration( GameState gameState )
    {
        if ( !HasSufficientFunds( gameState ) )
        {
            return;
        }

        int bet = GetValidBet( gameState.Balance );
        int randomNum = NumberGenerator.Generate();

        DisplayNumber( randomNum );
        ProcessResult( gameState, bet, randomNum );
    }
    private void DisplayNumber( int number )
    {
        Console.WriteLine( string.Format( Messages.NumberRolled, number ) );
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

    private void ProcessResult( GameState gameState, int bet, int randomNum )
    {
        if ( randomNum >= luckyNumberMin && randomNum <= luckyNumberMax )
        {
            int winAmount = WinResultCalculator.CalculateWinAmount( bet, randomNum, GameState.multiplex, luckyNumberMin );
            gameState.AddWinnings( winAmount );
            Console.WriteLine( string.Format( Messages.WinMessage, winAmount ) );
        }
        else
        {
            gameState.DeductBet( bet );
            Console.WriteLine( string.Format( Messages.LoseMessage, bet ) );
        }
    }
}