public interface IFighter
{
    string Name { get; }
    int Health { get; }
    int MaxHealth { get; }
    int Strength { get; }
    int Protection { get; }
    bool IsAlive { get; }

    void TakeDamage( int damage );
    int Attack();
}