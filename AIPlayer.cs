namespace Games.Dice.ThreeOrMore
{
    public class AIPlayer : Player
    {
        public AIPlayer(string name)
        {
            Name = name;
        }
        
        public override DiceRoll TakeTurn(Die dieConfig, int rollsCount)
        {
            return dieConfig.RollMultipleTimes(rollsCount);
        }
    }
}