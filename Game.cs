using System;

namespace Games.Dice.ThreeOrMore
{
    public class Game
    {
        public const int RollsPerGo = 5;
        public int MaxRounds { get; private set; }
        public Player[] Players { get; private set; }
        public Die DieConfig { get; private set; }
        public Game(int maxRounds, Player[] players, int diceSidesCount)
        {
            MaxRounds = maxRounds;
            Players = players;
            DieConfig = new Die(diceSidesCount);
        }

        public void StartGame()
        {
            Console.WriteLine($"Info: Starting game with {Players.Length} players for {MaxRounds} rounds");
            for (int i = 0; i < MaxRounds; i++)
            {
                Console.WriteLine($"\n\tROUND {i + 1}!\n");
                GameLoop();
            }
            Console.WriteLine("\n\tGame Finished!\n");
            Player[] sortedPlayers = Games.Utilities.Sorter.SortPlayerScores(Players);
            Console.WriteLine("Pos\tName\tScore");
            for (int i = sortedPlayers.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"{sortedPlayers.Length - i}\t{sortedPlayers[i].Name}\t{sortedPlayers[i].Score}");
            }
        }

        void GameLoop()
        {
            // Go through each Player object, ask for their dice rolls
            foreach (Player player in Players)
            {
                DiceRoll roll = player.TakeTurn(DieConfig, RollsPerGo);
                int[] valCount = new int[DieConfig.DieSideCount];
                foreach (int i in roll.Rolls)
                {
                    valCount[i - 1]++; // add 1 to counter for that number
                }
                int xOfKind = -1;
                int xOfKindVal = -1;
                for (int i = 0; i < valCount.Length; i++)
                {
                    // iterating through each count to find the highest. (An array where the roll number on the die is i + 1 and the number of times it happened is valCount[i])
                    if (valCount[i] > xOfKind)
                    {
                        // got a new highest x of kind
                        xOfKind = valCount[i];
                        xOfKindVal = i + 1;
                    }
                }

                switch (xOfKind)
                {
                    case 2:
                        Console.WriteLine($"{player.Name} only got 2 of a kind. You get 3 more re-rolls");
                        // TODO: Implement the re-rolling
                        break;
                    case 3:
                        Console.WriteLine($"{player.Name} got 3 of a kind! +3 points!");
                        player.Score += 3;
                        break;
                    case 4:
                        Console.WriteLine($"{player.Name} got 4 of a kind! +6 points!");
                        player.Score += 6;
                        break;
                    case 5:
                        Console.WriteLine($"{player.Name} got 5 of a kind! +12 points!");
                        player.Score += 12;
                        break;
                    default:
                        Console.WriteLine($"Unlucky... {player.Name} only got {xOfKind} of a kind! :(");
                        break;
                }

            }
            // if player has 3 of a kind or more, award the corresponding scores
            // else if the player has 2 of a kind, allow them to re-roll 3 more times (keeping the original 2 of a kind)
        }
    }
}