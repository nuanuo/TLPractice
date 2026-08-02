public class NumberGenerator
{
    private const int Min = 1;
    private const int Max = 20;
    private static readonly Random random = new Random();
    public static int Generate()
    {
        return random.Next( Min, Max + 1 );
    }
}