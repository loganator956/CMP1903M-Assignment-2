using System;
using Games.Dice;
using Games.Dice.ThreeOrMore;

namespace CMP1903M_Assignment_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // gather players
            Player[] players = new Player[2];
            players[0] = new HumanPlayer("Human");
            players[1] = new AIPlayer("AI");
            Game game = new Game(5, players, 6);
            game.StartGame();
        }
    }
}