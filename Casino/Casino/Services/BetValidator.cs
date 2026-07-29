public class BetValidator
{
    public bool IsValid( int bet, int maxBalance )
    {
        return bet > 0 && bet <= maxBalance;
    }

    public string GetErrorMessage( int bet, int maxBalance )
    {
        if ( bet > maxBalance )
            return string.Format( Messages.BetCannotExceedBalance, maxBalance );
        if ( bet <= 0 )
            return Messages.BetMustBePositive;
        return string.Empty;
    }
}
