public static class Messages
{
    public const string Banner =
        "#########################################\n" +
        " ####   ####   ####  ###### ##  ##  #### \n" +
        "##  ## ##  ## ##       ##   ### ## ##  ##\n" +
        "##     ######  ####    ##   ## ### ##  ##\n" +
        "##  ## ##  ##     ##   ##   ##  ## ##  ##\n" +
        " ####  ##  ##  ####  ###### ##  ##  #### \n" +
        "#########################################";

    public const string Welcome = "Добро пожаловать в CASINO!";
    public const string EnterInitialBalance = "Введите ваш начальный баланс: ";
    public const string InvalidNumber = "Ошибка: введите целое число!";
    public const string EmptyInput = "Ошибка: введите значение!";

    public const string ShowBalanceOption = "1. Посмотреть баланс";
    public const string MakeBetOption = "2. Сделать ставку";
    public const string ExitOption = "3. Выход";
    public const string PromptSelectAction = "Выберите действие:";
    public const string UnknownCommand = "Неверная команда.";

    public const string BalanceInfo = "Ваш баланс: {0}";
    public const string InsufficientFunds = "У вас недостаточно средств для игры!";
    public const string EnterBet = "Введите ставку: ";
    public const string BetCannotExceedBalance = "Ставка не может превышать баланс ({0})";
    public const string BetMustBePositive = "Ставка должна быть больше 0";
    public const string NumberRolled = "Выпало число: {0}";
    public const string WinMessage = "Победа! Вы выиграли {0}";
    public const string LoseMessage = "Проигрыш. Вы потеряли {0}";

    public const string Farewell = "До свидания!";

    public const string NegativeInitialBalance = "Начальный баланс не может быть отрицательным!";
    public const string NegativeWinAmount = "Сумма выигрыша не может быть отрицательной!";
    public const string NegativeBetAmount = "Ставка не может быть отрицательной!";


    public const string EnterNumber = "Ошибка: введите число!";
    public const string EnterPositiveNumber = "Ошибка: введите положительное целое число!";
    public const string EnterCommand = "Ошибка: введите команду!";
}