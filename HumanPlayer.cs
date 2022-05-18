namespace Games.Dice.ThreeOrMore
{
    /// <summary>
    /// A player who takes inputs from the keyboard to roll the die
    /// </summary>
    public class HumanPlayer : Player
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The human readable display name of the player</param>
        public HumanPlayer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Tells player to roll their die. Will ask for user to press any key to simulate a dice roll
        /// </summary>
        /// <param name="dieConfig">Reference to the Die class to get random values from</param>
        /// <param name="rollsCount">Amount of times to sample the dice</param>
        /// <returns>Information about the roll(s)</returns>
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