using System;

namespace Games.Dice
{
    public class Die
    {
        public int DieSideCount { get; private set; }
        
        private Random _random = new Random();

        public Die()
        {
            DieSideCount = 6;
        }

        public Die(int sideCount)
        {
            DieSideCount = sideCount;
        }

        public int RollOnce()
        {
            return _random.Next(1, DieSideCount);
        }

        public DiceRoll RollMultipleTimes(int count)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < count; i++)
            {
                rolls.Add(RollOnce());
            }
            return new DiceRoll(rolls.ToArray());
        }


        public static DiceRoll MultiDieRoll(int diceCount, int sidesCount)
        {
            Die[] dice = new Die[diceCount];
            for (int i = 0; i < diceCount; i++)
            {
                dice[i] = new Die(sidesCount);
            }
            return MultiDieRoll(dice);
        }

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