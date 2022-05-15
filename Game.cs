using System;

namespace Games.Dice.ThreeOrMore
{
    public class Game
    {
        public int MaxTurns { get; private set; }
        public Player[] Players { get; private set; }
        public Game(int maxTurns, Player[] players)
        {
            MaxTurns = maxTurns;
            Players = players;
        }

        public void StartGame()
        {
            for (int i = 0; i < MaxTurns; i++)
            {
                GameLoop();
            }
        }

        void GameLoop()
        {
            // Go through each Player object, ask for their dice rolls
            // Validate the dice rolls
                // if player has 3 of a kind or more, award the corresponding scores
                // else if the player has 2 of a kind, allow them to re-roll 3 more times (keeping the original 2 of a kind)
        }

        void CheckWinner()
        {
            // Go through each Player object, ask for their dice rolls
        }
    }
}