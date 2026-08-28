class Fighters
{
    static void Main()
    {
        BattleManager battleManager = new BattleManager();
        battleManager.StartBattle();

        Console.WriteLine( Messages.Goodbye );
    }
}