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

    private IRace SelectRace()
    {
        var races = new List<IRace> { new Human(), new Dwarf(), new Elf(), new Hobbit(), new Orc(), new Troll() };
        return SelectItem( races, Messages.SelectRace );
    }

    private ICaste SelectCaste()
    {
        var castes = new List<ICaste> { new Mercenary(), new Archer(), new Assassin(), new Knight() };
        return SelectItem( castes, Messages.SelectClass );
    }

    private IWeapon SelectWeapon()
    {
        var weapons = new List<IWeapon> { new BattleAxe(), new ButterflyBlade(), new ElvenBow(), new TwoHandedHammer(), new WizardsStaff() };
        return SelectItem( weapons, Messages.SelectWeapon );
    }

    private IArmor SelectArmor()
    {
        var armors = new List<IArmor> { new NoArmor(), new BoneArmor(), new DragonScale(), new ElvenCloak(), new IronChainmail(), new LeafChainmail() };
        return SelectItem( armors, Messages.SelectArmor );
    }

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