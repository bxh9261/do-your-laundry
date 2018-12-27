using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 21-FEB-2018
 * Prof. Warren
 * Config: for configuring Laundry Adventure
 */
namespace HomeworkHanel
{
    class Config
    {
        public static int rollDice(int sides1, int sides2) //rolls a die for an int between sides1 and sides2
        {
            Random die1 = new Random();
            int dieroll1 = die1.Next(sides1, (sides2+1)); //rolls a die for an int between sides1 and sides2
            return (dieroll1);
        }

        public static int rollDice(int sides1, int sides2, int dice) //rolls a die for an int between sides1 and sides2
        {
            Random die2 = new Random();
            int dieroll2 = die2.Next(sides1, (sides2 + 1)); //rolls a die for an int between sides1 and sides2
            dieroll2 = dieroll2 * dice;
            dieroll2 = dieroll2/dice;
            return (dieroll2);
        }

        public static void GameEnd() //ends the game
        {
            Console.WriteLine("Goodbye.");
            Environment.Exit(0);
        }
    }
}
