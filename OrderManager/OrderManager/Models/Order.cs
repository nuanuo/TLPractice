public class Order
{
    public string ProductName { get; }
    public int ProductQuantity { get; }
    public string Username { get; }
    public string DeliveryAddress { get; }
    public Order( string productName, int productQuantity, string username, string deliveryAddress )
    {
        if ( string.IsNullOrWhiteSpace( productName ) )
            throw new ArgumentException( "Название товара обязательно!" );
        if ( productQuantity <= 0 )
            throw new ArgumentException( "Количество товара должно быть положительным!" );
        if ( string.IsNullOrWhiteSpace( username ) )
            throw new ArgumentException( "Имя обязательно!" );
        if ( string.IsNullOrWhiteSpace( deliveryAddress ) )
            throw new ArgumentException( "Адрес доставки обязателен!" );
        ProductName = productName;
        ProductQuantity = productQuantity;
        Username = username;
        DeliveryAddress = deliveryAddress;
    }
}