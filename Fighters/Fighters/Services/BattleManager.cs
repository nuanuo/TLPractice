public class BattleManager
{
    public void StartBattle( IFighter fighter1, IFighter fighter2 )
    {
        int round = 1;
        Console.WriteLine( Messages.BattleStart );

        while ( fighter1.IsAlive && fighter2.IsAlive )
        {
            Console.WriteLine( string.Format( Messages.Round, round ) );

            int damage1 = fighter1.Attack();
            int actualDamage1 = Math.Max( 0, damage1 - fighter2.Protection );
            fighter2.TakeDamage( actualDamage1 );
            Console.WriteLine( string.Format( Messages.AttackMessage, fighter1.Name, actualDamage1, fighter2.Name ) );

            if ( !fighter2.IsAlive )
            {
                Console.WriteLine( string.Format( Messages.FighterDied, fighter2.Name ) );
                Console.WriteLine( string.Format( Messages.Victory, fighter1.Name ) );
                return;
            }

            int damage2 = fighter2.Attack();
            int actualDamage2 = Math.Max( 0, damage2 - fighter1.Protection );
            fighter1.TakeDamage( actualDamage2 );
            Console.WriteLine( string.Format( Messages.AttackMessage, fighter2.Name, actualDamage2, fighter1.Name ) );

            if ( !fighter1.IsAlive )
            {
                Console.WriteLine( string.Format( Messages.FighterDied, fighter1.Name ) );
                Console.WriteLine( string.Format( Messages.Victory, fighter2.Name ) );
                return;
            }

            round++;
        }
    }
}
