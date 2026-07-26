public class MakingAnOrder
{
    private const string ConfirmPrompt = "Нажмите Y для подтверждения или любую другую клавишу для отмены.";
    private const string ErrorEmptyField = "Ошибка: поле не может быть пустым!";
    private const string ErrorInvalidNumber = "Ошибка: введите положительное целое число!";

    private const string YesResponse = "Y";
    private const string YesResponseLower = "y";

    public bool OrderConfirmation( Order orderDetails )
    {
        Console.WriteLine( $"Здравствуйте, {orderDetails.Username}, вы заказали {orderDetails.ProductQuantity} {orderDetails.ProductName} на адрес {orderDetails.DeliveryAddress}, все верно?" );
        Console.WriteLine( ConfirmPrompt );
        string c = Console.ReadLine() ?? string.Empty;

        if ( c == YesResponse || c == YesResponseLower )
        {
            DateTime today = DateTime.Today;
            Console.WriteLine( $"{orderDetails.Username}! Ваш заказ {orderDetails.ProductName} в количестве {orderDetails.ProductQuantity} оформлен! Ожидайте доставку по адресу {orderDetails.DeliveryAddress} к {today.AddDays( 3 ):dd.MM.yyyy}" );
            return true;
        }
        else
        {
            return false;
        }
    }
    public Order CreatingAnOrder()
    {
        string productName = GetNonEmptyInput( "Введите название товара: " );
        int productQuantity = GetPositiveInt( "Введите количество товара: " );
        string username = GetNonEmptyInput( "Введите ваше имя: " );
        string deliveryAddress = GetNonEmptyInput( "Введите адрес доставки: " );

        return new Order( productName, productQuantity, username, deliveryAddress );
    }

    private string GetNonEmptyInput( string strInput )
    {
        while ( true )
        {
            Console.Write( strInput );
            string input = Console.ReadLine() ?? string.Empty;

            if ( !string.IsNullOrEmpty( input ) )
            {
                return input;
            }
                
            Console.WriteLine( ErrorEmptyField );
        }
    }

    private int GetPositiveInt( string strInput )
    {
        while ( true )
        {
            Console.Write( strInput );
            string input = Console.ReadLine() ?? string.Empty;

            if ( int.TryParse( input, out int result ) && result > 0 )
            {
                return result;
            }    

            Console.WriteLine( ErrorInvalidNumber );
        }
    }

}