namespace Games.Dice.ThreeOrMore
{
    /// <summary>
    /// A type of player who doesn't take keyboard inputs and returns the values instantly.
    /// </summary>
    public class AIPlayer : Player
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The human readable display name of the player</param>
        public AIPlayer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Tells player to roll their die. AI players simply do not simulate any input presses and return the random values instantly.
        /// </summary>
        /// <param name="dieConfig">Reference to the Die class to get random values from</param>
        /// <param name="rollsCount">Amount of times to sample the dice</param>
        /// <returns>Information about the roll(s)</returns>
        public override DiceRoll TakeTurn(Die dieConfig, int rollsCount)
        {
            return dieConfig.RollMultipleTimes(rollsCount);
        }
    }
}