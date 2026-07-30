public static class WinResultCalculator
{
    public static int CalculateWinAmount( int bet, int randomNum, int multiplex, int luckyNumber )
    {
        return bet * ( 1 + multiplex * ( randomNum % ( luckyNumber - 1 ) ) );
    }
}