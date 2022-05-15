using System;
using Games.Dice;

namespace CMP1903M_Assignment_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Die.MultiDieRoll(2, 6).ToString("%t from %rs"));
        }
    }
}