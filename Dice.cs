using System;

namespace Games.Dice
{
    /// <summary>
    /// Creates a die that rolls random values within a range
    /// </summary>
    public class Die
    {
        /// <summary>
        /// Maximum value that the die may roll
        /// </summary>
        public int DieSideCount { get; private set; }

        private Random _random = new Random();

        /// <summary>
        /// Basic default constructor. Creates a 6 sided die
        /// </summary>
        public Die()
        {
            DieSideCount = 6;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sideCount">Maximum value that the die may roll</param>
        public Die(int sideCount)
        {
            if (sideCount <= 0) { throw new DiceSetupParameterException($"{sideCount} is out of rollable range"); };
            DieSideCount = sideCount;
        }

        /// <summary>
        /// Get a random roll value
        /// </summary>
        /// <returns>The integer value of the roll</returns>
        public int RollOnce()
        {
            return _random.Next(1, DieSideCount + 1);
        }

        /// <summary>
        /// Get a random roll value
        /// </summary>
        /// <param name="count">Number of times to roll</param>
        /// <returns>The results of the dice roll</returns>
        public DiceRoll RollMultipleTimes(int count)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < count; i++)
            {
                rolls.Add(RollOnce());
            }
            return new DiceRoll(rolls.ToArray());
        }


        /// <summary>
        /// Roll multiple dice without creating new classes.
        /// </summary>
        /// <param name="diceCount">Number of dice to create</param>
        /// <param name="sidesCount">Number of sides on them</param>
        /// <returns></returns>
        public static DiceRoll MultiDieRoll(int diceCount, int sidesCount)
        {
            Die[] dice = new Die[diceCount];
            for (int i = 0; i < diceCount; i++)
            {
                dice[i] = new Die(sidesCount);
            }
            return MultiDieRoll(dice);
        }

        /// <summary>
        /// Roll multiple pre-created dice
        /// </summary>
        /// <param name="dice">The dice to roll</param>
        /// <returns>The results of the dice rolls</returns>
        public static DiceRoll MultiDieRoll(Die[] dice)
        {
            List<int> rolls = new List<int>();
            foreach (Die die in dice)
            {
                rolls.Add(die.RollOnce());
            }
            return new DiceRoll(rolls.ToArray());
        }
    }

    [System.Serializable]
    /// <summary>
    /// Something went wrong setting up the dice
    /// </summary>
    public class DiceSetupParameterException : System.Exception
    {
        public DiceSetupParameterException() { }
        public DiceSetupParameterException(string message) : base(message) { }
        public DiceSetupParameterException(string message, System.Exception inner) : base(message, inner) { }
        protected DiceSetupParameterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}