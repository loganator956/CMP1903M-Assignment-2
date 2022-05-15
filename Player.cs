using System;

namespace Games.Dice.ThreeOrMore
{
    public abstract class Player
    {
        public int Score { get; set; }
        
        public abstract DiceRoll TakeTurn();
    }
}