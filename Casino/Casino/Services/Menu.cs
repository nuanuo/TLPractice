public class CasinoGame
{
    private readonly GameState gameState;
    private readonly Gameplay gameplay;

    public CasinoGame()
    {
        Console.WriteLine( Messages.Banner );
        Console.WriteLine( Messages.Welcome );
        Console.WriteLine();

        int balance = ReadInitialBalance();
        gameState = new GameState( balance );
        gameplay = new Gameplay();
    }

    private int ReadInitialBalance()
    {
        while ( true )
        {
            Console.Write( Messages.EnterInitialBalance );
            string input = Console.ReadLine() ?? string.Empty;
            if ( string.IsNullOrWhiteSpace( input ) )
            {
                Console.WriteLine( "Ошибка: введите число!" );
                continue;
            }

            if ( int.TryParse( input, out int balance ) && balance >= 0 )
                return balance;

            Console.WriteLine( "Ошибка: введите положительное целое число!" );
        }
    }

    public void WriteMenu()
    {
        Console.WriteLine( Messages.PromptSelectAction );
        Console.WriteLine( Messages.ShowBalanceOption );
        Console.WriteLine( Messages.MakeBetOption );
        Console.WriteLine( Messages.ExitOption );
    }

    public void Start()
    {
        WriteMenu();
        while ( true )
        {
            string command = Console.ReadLine() ?? string.Empty;

            if ( string.IsNullOrWhiteSpace( command ) )
            {
                Console.WriteLine( "Ошибка: введите команду!" );
                WriteMenu();
                continue;
            }

            switch ( command )
            {
                case "1":
                    Console.WriteLine( string.Format( Messages.BalanceInfo, gameState.Balance ) );
                    WriteMenu();
                    break;
                case "2":
                    gameplay.GameIteration( gameState );
                    WriteMenu();
                    break;
                case "3":
                    Console.WriteLine( Messages.Farewell );
                    return;
                default:
                    Console.WriteLine( Messages.UnknownCommand );
                    WriteMenu();
                    break;
            }
        }
    }
}