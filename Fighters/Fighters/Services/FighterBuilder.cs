public class FighterBuilder
{
    public Fighter CreateFighter()
    {
        string name = GetValidName();
        IRace race = SelectRace();
        ICaste caste = SelectCaste();
        IWeapon weapon = SelectWeapon();
        IArmor armor = SelectArmor();

        return new Fighter( name, race, caste, weapon, armor );
    }

    private string GetValidName()
    {
        while ( true )
        {
            Console.WriteLine( Messages.EnterName );
            string input = Console.ReadLine() ?? string.Empty;

            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                return input;
            }

            Console.WriteLine( Messages.NameRequired );
        }
    }

    private static readonly List<IRace> Races = new List<IRace>
    {
        new Human(),
        new Dwarf(),
        new Elf(),
        new Hobbit(),
        new Orc(),
        new Troll()
    };

    private static readonly List<ICaste> Castes = new List<ICaste>
    {
        new Knight(),
        new Archer(),
        new Mercenary(),
        new Assassin()
    };

    private static readonly List<IWeapon> Weapons = new List<IWeapon>
    {
        new ElvenBow(),
        new TwoHandedHammer(),
        new ButterflyBlade(),
        new BattleAxe(),
        new WizardsStaff()
    };

    private static readonly List<IArmor> Armors = new List<IArmor>
    {
        new NoArmor(),
        new LeafChainmail(),
        new DragonScale(),
        new BoneArmor(),
        new ElvenCloak(),
        new IronChainmail()
    };

    private IRace SelectRace() => SelectItem( Races, Messages.SelectRace );
    private ICaste SelectCaste() => SelectItem( Castes, Messages.SelectCaste );
    private IWeapon SelectWeapon() => SelectItem( Weapons, Messages.SelectWeapon );
    private IArmor SelectArmor() => SelectItem( Armors, Messages.SelectArmor );

    private T SelectItem<T>( List<T> items, string prompt ) where T : class
    {
        while ( true )
        {
            Console.WriteLine( prompt );

            for ( int i = 0; i < items.Count; i++ )
            {
                Console.WriteLine( $"{i + 1}. {items[ i ]}" );
            }

            string input = Console.ReadLine() ?? string.Empty;
            if ( int.TryParse( input, out int choice ) && choice >= 1 && choice <= items.Count )
            {
                return items[ choice - 1 ];
            }

            Console.WriteLine( Messages.InvalidChoice );
        }
    }
}