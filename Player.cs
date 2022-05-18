using System;

namespace Games.Dice.ThreeOrMore
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        
        public abstract DiceRoll TakeTurn(Die dieConfig, int rollsCount);
    }
}