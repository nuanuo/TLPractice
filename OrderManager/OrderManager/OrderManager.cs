class OrderManager
{
    public static void Main()
    {
        Console.WriteLine( "Оформление заказа." );

        while ( true )
        {
            MakingAnOrder orderProcessor = new MakingAnOrder();
            Order newOrder = orderProcessor.CreatingAnOrder();

            bool isConfirmed = orderProcessor.OrderConfirmation( newOrder );

            if ( isConfirmed )
            {
                break;
            }
            else
            {
                Console.WriteLine( "Введите информацию заново." );
            }
        }
        Console.WriteLine( "Спасибо за заказ!" );
    }
}