public class Order
{
    public string ProductName { get; set; } = string.Empty;
    public int ProductQuantity { get; set; }
    public string Username { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
}
public class MakingAnOrder
{
    public bool DataConfirmation( Order orderDetails )
    {
        Console.WriteLine( $"Здравствуйте, {orderDetails.Username}, вы заказали {orderDetails.ProductQuantity} {orderDetails.ProductName} на адрес {orderDetails.DeliveryAddress}, все верно?" );
        Console.WriteLine( "Нажмите Y, если все верно, или любой другой символ для исправления данных." );
        string c = Console.ReadLine() ?? string.Empty;

        if ( c == "Y" || c == "y" )
        {
            var today = DateTime.Today;
            Console.WriteLine( $"{orderDetails.Username}! Ваш заказ {orderDetails.ProductName} в количестве {orderDetails.ProductQuantity} оформлен! Ожидайте доставку по адресу {orderDetails.DeliveryAddress} к {today.AddDays( 3 ):dd.MM.yyyy}" );
            return true;
        }
        else
        {
            return false;
        }
    }
    public Order GetOrderDetails()
    {
        Order order = new Order();

        Console.Write( "Введите название товара: " );
        order.ProductName = Console.ReadLine() ?? string.Empty;

        Console.Write( "Введите количество товара: " );
        string quantityStr = Console.ReadLine() ?? string.Empty;
        order.ProductQuantity = int.Parse( quantityStr );

        Console.Write( "Введите ваше имя: " );
        order.Username = Console.ReadLine() ?? string.Empty;

        Console.Write( "Введите адрес доставки: " );
        order.DeliveryAddress = Console.ReadLine() ?? string.Empty;

        Console.WriteLine();
        return order;
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine( "Оформление заказа." );
        Console.WriteLine();
        bool orderCompleted = false;

        while ( !orderCompleted )
        {
            MakingAnOrder orderProcessor = new MakingAnOrder();
            Order newOrder = orderProcessor.GetOrderDetails();

            bool isConfirmed = orderProcessor.DataConfirmation( newOrder );

            if ( isConfirmed )
            {
                orderCompleted = true;
            }
            else
            {
                Console.WriteLine( "Введите информацию заново." );
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        Console.WriteLine( "Спасибо за заказ!" );
    }
}