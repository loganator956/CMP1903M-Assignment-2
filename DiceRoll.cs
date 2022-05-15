using System;
using System.Collections.Generic;

namespace Games.Dice
{
    public struct DiceRoll
    {
        public int[] Rolls { get; private set; }
        public int Total { get; private set; }

        public DiceRoll(int[] rolls)
        {
            Rolls = rolls;

            Total = 0;
            foreach(int i in Rolls)
            {
                Total += i;
            }
        }

        public override string ToString()
        {
            return Total.ToString();
        }

        public string ToString(string format)
        {
            string rs = "";
            foreach(int r in Rolls)
            {
                rs += r.ToString() + " ";
            }
            return format.Replace("%t", Total.ToString()).Replace("%rs", rs);
        }
    }
}