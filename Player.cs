using System;

namespace Games.Dice.ThreeOrMore
{
    /// <summary>
    /// A player of the three or more game
    /// </summary>
    public abstract class Player
    {
        public Player()
        {
            Name = string.Empty;
        }
        /// <summary>
        /// The human-readable display name of the player
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// The current score property of the player
        /// </summary>
        /// <value></value>
        public int Score { get; set; }
        
        /// <summary>
        /// Tells the player to roll the dice for their turn.
        /// </summary>
        /// <param name="dieConfig">Reference to the Die class to get random values from</param>
        /// <param name="rollsCount">Number of times to roll the die</param>
        /// <returns></returns>
        public abstract DiceRoll TakeTurn(Die dieConfig, int rollsCount);
    }
}