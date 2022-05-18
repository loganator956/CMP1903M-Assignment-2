using System;
using Games.Dice.ThreeOrMore;

namespace Games.Utilities
{
    public static class Sorter
    {
        public static Player[] SortPlayerScores(Player[] players)
        {
            for (int j = 0; j < players.Length - 1; j++)
            {
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (!(players[i].Score < players[i + 1].Score))
                    {
                        // need to swap the two vallus
                        Player t = players[i + 1];
                        players[i + 1] = players[i];
                        players[i] = t;
                    }
                }
            }
            return players;
        }
    }
}