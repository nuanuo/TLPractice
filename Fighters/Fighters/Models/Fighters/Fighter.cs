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
        return Strength;
    }

    public void TakeDamage( int damage )
    {
        Health -= damage;

        if ( Health < 0 )
        {
            Health = 0;
        }      
    }
}