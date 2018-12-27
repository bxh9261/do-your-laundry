using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Bradley Hanel
 * 21-FEB-2018
 * Prof. Warren
 * Yard: runs program while user is in the yard
 */
namespace HomeworkHanel
{
    class Yard
    {
        /*After you read the introduction, you can go in any direction. If you go west, you go to your neighbors house, and he gets annoyed you're on his lawn and drives you back to the end of the driveway.
         * North will lead you to the front door of your house.
         * East will lead you to your other neighbor's house, where you're blocked off by the neighbor mowing their lawn.
         * South is blocked by the busy street. If you go south you get hit by a car and have to restart.
         */



        public void ExploreYard() //method for starting the exploring of the first area -- the yard
        {
            const int STEPS = 5; //number of steps from the start point to the front door
            int stepinput = 0;

            Console.WriteLine("You'll start by going north towards your house. Enter the number of steps you'll take towards it.");

            for (int pos = 0; pos < STEPS; pos += stepinput)
            {
                while (!int.TryParse(Console.ReadLine(), out stepinput)) //checks to make sure the user actually input an integer number of steps
                {
                    Console.WriteLine("This is not a valid number of steps.");
                }

                if ((pos + stepinput) >= 0)
                {
                    Console.WriteLine("You've gone " + (pos + stepinput) + " steps towards the front door, but you're not there yet!");
                }
                
                else
                {
                    Console.WriteLine("You walk into the street and get hit by a bus. You are dead.");
                    Config.GameEnd();
                }
            }

            Console.WriteLine("You're now at the front door.");


        }
        public bool FrontDoor(Setup setup) //method for what happens once you get up to the front door
        {
            string name = setup.GetCharacterName();

            Console.WriteLine("What is your last name?");
            name = name + (" " + Console.ReadLine().Trim());
            setup.SetCharacterName(name);
            Console.WriteLine("Your name is " + setup.GetCharacterName());


            Console.WriteLine("You try to open the door but there's a note on the door. It reads: \n");
            Console.WriteLine("Dear " + setup.GetCharacterName() + ", \n Went out to get some milk. The key is under the mat. \n <3 Dad");
            int dice = Config.rollDice(1,6);
            int d2 = Config.rollDice(1,6,10);
            int totaldice = dice + d2;
            Console.WriteLine(setup.GetCharacterName() + " rolls a " + (totaldice)); //checks to see if the sum if die rolls is less than or equal to 4. If so, you die.
            if ((totaldice) <= 2)
            {
                Console.WriteLine("You check under the mat.");
                Console.ReadLine();
                Console.WriteLine("You are attacked by a sock.");
                Console.ReadLine();
                Console.WriteLine("You are dead.");
                Config.GameEnd();
                return false;
            }
            else
            {
                Console.WriteLine("You knock on the door. It swings open.");
                return true;
            }
            
        }

    }
}
