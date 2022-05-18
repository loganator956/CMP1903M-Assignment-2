namespace Games.Dice.ThreeOrMore
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name)
        {
            Name = name;
        }
        public override DiceRoll TakeTurn(Die dieConfig, int rollsCount)
        {
            return dieConfig.RollMultipleTimes(rollsCount);
            // TODO: Add some user input to make seem like you're rolling them
        }
    }
}