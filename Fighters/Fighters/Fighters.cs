class Fighters
{
    static void Main()
    {
        Console.WriteLine( Messages.Welcome );

        FighterBuilder builder = new();
        BattleManager battleManager = new();

        Console.WriteLine( "\nСоздание первого бойца:" );
        IFighter fighter1 = builder.CreateFighter();

        Console.WriteLine( "\nСоздание второго бойца:" );
        IFighter fighter2 = builder.CreateFighter();

        Console.WriteLine( "\nНачало битвы!" );
        battleManager.StartBattle( fighter1, fighter2 );

        Console.WriteLine( Messages.Goodbye );
    }
}