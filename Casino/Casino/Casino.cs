Console.WriteLine( "#########################################" );
Console.WriteLine( " ####   ####   ####  ###### ##  ##  #### " );
Console.WriteLine( "##  ## ##  ## ##       ##   ### ## ##  ##" );
Console.WriteLine( "##     ######  ####    ##   ## ### ##  ##" );
Console.WriteLine( "##  ## ##  ##     ##   ##   ##  ## ##  ##" );
Console.WriteLine( " ####  ##  ##  ####  ###### ##  ##  #### " );
Console.WriteLine( "#########################################" );
Console.WriteLine( "Добро пожаловать в CASINO!" );
Console.WriteLine();

Console.Write( "Введите ваш начальный баланс: " );
string balanceStr = Console.ReadLine() ?? string.Empty;
int balance = int.Parse( balanceStr );

Console.WriteLine();
Console.WriteLine( "Выберите действие:" );
Console.WriteLine( "1. Посмотреть баланс" );
Console.WriteLine( "2. Сделать ставку" );
Console.WriteLine( "3. Выход" );

int multiplex = 2;
string command = string.Empty;

while ( true )
{
    command = Console.ReadLine() ?? string.Empty;

    if ( command == "1" )
    {
        Console.WriteLine( $"Ваш баланс: {balance}" );
        Console.WriteLine();
        Console.WriteLine( "Выберите действие:" );
        Console.WriteLine( "1. Посмотреть баланс" );
        Console.WriteLine( "2. Сделать ставку" );
        Console.WriteLine( "3. Выход" );
    }
    else if ( command == "2" )
    {
        GameIteration();
        Console.WriteLine();
        Console.WriteLine( "Выберите действие:" );
        Console.WriteLine( "1. Посмотреть баланс" );
        Console.WriteLine( "2. Сделать ставку" );
        Console.WriteLine( "3. Выход" );
    }
    else if ( command == "3" )
    {
        Console.WriteLine( "До свидания!" );
        break;
    }
    else
    {
        Console.WriteLine( "Неверная команда." );
        Console.WriteLine();
        Console.WriteLine( "Выберите действие:" );
        Console.WriteLine( "1. Посмотреть баланс" );
        Console.WriteLine( "2. Сделать ставку" );
        Console.WriteLine( "3. Выход" );
    }
}

void GameIteration()
{
    if ( balance <= 0 )
    {
        Console.WriteLine( "У вас недостаточно средств для игры!" );
        return;
    }

    Console.Write( "Введите ставку: " );
    string betStr = Console.ReadLine() ?? string.Empty;
    int bet = int.Parse( betStr );

    while ( bet > balance || bet <= 0 )
    {
        if ( bet > balance )
        {
            Console.WriteLine( $"Ставка не может превышать баланс ({balance})" );
        }
        else if ( bet <= 0 )
        {
            Console.WriteLine( "Ставка должна быть больше 0" );
        }
        Console.Write( "Введите ставку: " );
        betStr = Console.ReadLine() ?? string.Empty;
        bet = int.Parse( betStr );
    }

    int randomNum = Random.Shared.Next( 1, 21 );
    Console.WriteLine( $"Выпало число: {randomNum}" );

    if ( randomNum >= 18 )
    {
        int winAmount = bet * ( 1 + multiplex * ( randomNum % 17 ) );
        balance += winAmount;
        Console.WriteLine( $"Победа! Вы выиграли {winAmount}" );
    }
    else
    {
        balance -= bet;
        Console.WriteLine( $"Проигрыш. Вы потеряли {bet}" );
    }
}