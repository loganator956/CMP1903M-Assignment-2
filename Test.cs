using System;
using Games.Dice;

namespace CMP1903M_Assignment_2
{
    /// <summary>
    /// Contains several testing functions
    /// </summary>
    public static class Test
    {
        public static void TestDiceRoll()
        {
            int[] vals = new int[6];

            Die die = new Die(6);

            for (int i = 0; i < 200; i++)
            {
                vals[die.RollOnce() - 1]++;
            }
            
            Console.WriteLine("Assuming there was no index out of range exceptions, the dice rolled:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1} {vals[i]} times");
            }
        }
    }
}