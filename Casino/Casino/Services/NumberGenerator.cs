public class NumberGenerator
{
    private Random random = new Random();
    private const int Max = 20;
    private const int Min = 1;

    public int Generate()
    {
        return random.Next( Min, Max + 1 );
    }
}