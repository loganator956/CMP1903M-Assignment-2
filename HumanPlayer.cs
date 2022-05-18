namespace Games.Dice.ThreeOrMore
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name)
        {
            Name = name;
        }
        public override DiceRoll TakeTurn(Die dieConfig, int rollsCount)
        {
            DiceRoll roll =  dieConfig.RollMultipleTimes(rollsCount);
            foreach(int r in roll.Rolls)
            {
                Console.WriteLine("Press any key to roll...");
                Console.ReadKey();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"\r{Die.MultiDieRoll(1, 6)}");
                    Thread.Sleep(75);
                }
                Console.Write($"\r{r}\n");
            }
            return roll;
        }
    }
}