using System;

namespace Games.Dice.ThreeOrMore
{
    /// <summary>
    /// Implementation of the Three or More game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Number of times to roll the dice per turn.
        /// </summary>
        public const int RollsPerGo = 5;
        /// <summary>
        /// Number of rounds to be completed.
        /// </summary>
        public int MaxRounds { get; private set; }
        /// <summary>
        /// Array of all players
        /// </summary>
        public Player[] Players { get; private set; }
        /// <summary>
        /// The die that all players roll. (To ensure that they are random as multiple instances created at the same time will have the same seed)
        /// </summary>
        public Die DieConfig { get; private set; }
        public Game(int maxRounds, Player[] players, int diceSidesCount)
        {
            MaxRounds = maxRounds;
            Players = players;
            DieConfig = new Die(diceSidesCount);
        }

        /// <summary>
        /// Main entrypoint into the game
        /// </summary>
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

        private void GameLoop()
        {
            // Go through each Player object, ask for their dice rolls
            foreach (Player player in Players)
            {
                DiceRoll roll = player.TakeTurn(DieConfig, RollsPerGo);

                int newPoints = CalculatePointsForRolls(roll, player);
                Console.WriteLine($"{player.Name} +{newPoints} points!");
                player.Score += newPoints;
            }
            // if player has 3 of a kind or more, award the corresponding scores
            // else if the player has 2 of a kind, allow them to re-roll 3 more times (keeping the original 2 of a kind)
        }

        int CalculatePointsForRolls(DiceRoll roll, Player currentPlayer)
        {
            return CalculatePointsForRolls(roll, currentPlayer, true);
        }

        int CalculatePointsForRolls(DiceRoll roll, Player currentPlayer, bool allowReroll)
        {
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
                    if (allowReroll)
                    {
                        Console.WriteLine($"{currentPlayer.Name} Had 2 of a kind! Re-roll the rest!");
                        DiceRoll newRoll = currentPlayer.TakeTurn(DieConfig, RollsPerGo - 2);
                        List<int> newRollList = new List<int>();
                        newRollList.Add(roll.Rolls[0]);
                        newRollList.Add(roll.Rolls[1]);
                        newRollList.Add(newRoll.Rolls[0]);
                        newRollList.Add(newRoll.Rolls[1]);
                        newRollList.Add(newRoll.Rolls[2]);
                        return CalculatePointsForRolls(new DiceRoll(newRollList.ToArray()), currentPlayer, false);
                    }
                    else return 0;
                case 3:
                    return 3;
                case 4:
                    return 6;
                case 5:
                    return 12;
                default:
                    return 0;
            }
        }
    }
}