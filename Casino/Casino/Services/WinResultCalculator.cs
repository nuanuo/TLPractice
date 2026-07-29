public class WinResultCalculator
{
    public int CalculateWinAmount( int bet, int randomNum, int multiplex )
    {
        return bet * ( 1 + multiplex * ( randomNum % ( Gameplay.luckyNumber - 1 ) ) );
    }
}