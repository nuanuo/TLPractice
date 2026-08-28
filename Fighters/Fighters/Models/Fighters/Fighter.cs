public class Fighter : IFighter
{
    public string Name { get; }
    public IRace Race { get; }
    public ICaste Caste { get; }
    public IWeapon Weapon { get; }
    public IArmor Armor { get; }

    public int MaxHealth { get; private set; }
    public int Health { get; private set; }
    public int Strength { get; private set; }
    public int Protection { get; private set; }
    public bool IsAlive => Health > 0;

    private const int MinAttackPercent = -20;
    private const int MaxAttackPercent = 10;
    private const int CriticalChancePercent = 15;
    private const int CriticalMultiplier = 2;

    private static readonly Random _random = new Random();

    public Fighter( string name, IRace race, ICaste caste, IWeapon weapon, IArmor armor )
    {
        Name = name;
        Race = race;
        Caste = caste;
        Weapon = weapon;
        Armor = armor;

        CalculateStats();
    }

    public void CalculateStats()
    {
        Strength = Race.Strength + Caste.StrengthBonus + Weapon.StrengthBonus;
        MaxHealth = Race.Health + Caste.HealthBonus;
        Protection = Race.Armor + Armor.ArmorBonus;
        Health = MaxHealth;
    }

    public int Attack()
    {
        int baseDamage = Strength;

        double randomPercent = MinAttackPercent + ( MaxAttackPercent - MinAttackPercent ) * _random.NextDouble();
        double modifiedDamage = baseDamage * ( 1 + randomPercent / 100 );

        if ( _random.Next( 100 ) < CriticalChancePercent )
        {
            modifiedDamage *= CriticalMultiplier;
            Console.WriteLine( $"Критический урон! {Name} наносит {modifiedDamage:F0} урона!" );
        }

        int finalDamage = Math.Max( 1, ( int )Math.Round( modifiedDamage ) );

        return finalDamage;
    }

    public void TakeDamage( int damage )
    {
        if ( damage < 0 )
        {
            Console.WriteLine( Messages.DamageCannotBeNegative );
            return;
        }

        Health -= damage;
        if ( Health < 0 )
        {
            Health = 0;
        }
    }
}