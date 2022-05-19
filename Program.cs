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
            Test.TestDiceRoll();
            Player[] players = new Player[2];
            players[0] = new HumanPlayer("Human");
            players[1] = new AIPlayer("AI");
            Game game = new Game(5, players, 6);
            game.StartGame();
            Console.WriteLine("Game has finished. Would you like to go again? [y/N]");
            string input = Console.ReadLine() ?? "n";
            if (input[0] == 'y' || input[0] == 'Y')
            {
                Console.WriteLine("Starting again...");
                Main(args);
            }
            else
            {
                Console.WriteLine("Exiting :)");
            }
        }
    }
}