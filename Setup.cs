using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 21-FEB-2018
 * Prof. Warren
 * Setup: opening to Laundry Adventure
 */
namespace HomeworkHanel
{
    class Setup
    {
        
        private string Name;
        private int[] personal = new int[5];
        private List<string> UserFood = new List<string> { };

        public string GetCharacterName()
        {
            return Name;
        }

        public void SetCharacterName(string Nom)
        {
            Name = Nom;
        }

        public int[] GetNumbers()
        {
            return personal;
        }
        public void SetNumbers(int[] numbers)
        {
            personal = numbers;
        }
        public List<String> GetUserFood()
        {
            return UserFood;
        }
        public void SetUserFood(List <string> LoserFood)
        {
            UserFood = LoserFood;
        }
        public void GetCharacter() //asks for character name and saves it in Program for use later. also explains the game
        {
            //The game begins with you at the end of the driveway in front of your house. To the west is a mailbox, containing an envelope with the introduction to the game inside.

            Console.WriteLine("You've just gotten off the bus after another long day at school. \n Before you go in to your house, you should check to see if you have any mail. \n Type 'check mailbox' to continue.");

            //makes them check the mailbox whether they tell the player to or not
            string response = Console.ReadLine();
            response = response.Trim().ToLower();

            while (response != "check mailbox")
            {
                Console.WriteLine("Type 'check mailbox' to continue.");
                response = Console.ReadLine();
                response = response.Trim().ToLower();
            }
            Console.WriteLine("You check the mailbox. \n Inside is an envelope with only your name sloppily written on it in pen.");

            //asks user for name and stores it in 'name'
            Console.WriteLine("By the way, what is your name?");
            SetCharacterName(Console.ReadLine().Trim());

            Console.WriteLine(GetCharacterName() + ", huh? That's a lovely name! \n");

        }
        public void Introduction() //introduction for the game, asks if they're ready to begin, quits if not
        {
            string response; //stores various player responses throughout game

            //written contents of the letter
            Console.WriteLine("Anyway, you open the envelope to reveal a piece of paper, with these words printed on it in comic sans: \n");
            Console.WriteLine("Welcome to Laundry Adventure! \n Now's the time to have fun and explore your world. \n Your house is to the north if you'd like to start there.");
            Console.WriteLine("Are you ready to begin? (Y/N)");

            //reads user response and displays it back
            response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                response = response.Substring(0, 1);
                //Console.WriteLine(response);
                response = response.ToUpper();
                //Console.WriteLine(response);
            }

            while (response != "Y" && response != "N")
            {
                Console.WriteLine("Try again.");
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Substring(0, 1);
                    //Console.WriteLine(response);
                    response = response.ToUpper();
                    //Console.WriteLine(response);
                }
            }
            if (response == "Y")
            {
                Console.WriteLine("You express your readiness out loud as if the paper can actually hear you. Good luck, " + GetCharacterName());
            }
            else if (response == "N")
            {
                Config.GameEnd();
            }
        }

        public void IntegerInfo(Setup setup) //asks user for integers to be used later
        {
            Console.WriteLine("Before we begin, we must ask you some questions to personalize the game for you.");
            Console.WriteLine("First, we need 5 numbers between 10 and 100");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter number " + (i + 1) + ":");
                while ((!int.TryParse(Console.ReadLine(), out setup.GetNumbers()[i])) || setup.GetNumbers()[i] > 100 || setup.GetNumbers()[i] < 10) //checks to make sure the user actually input a number 10-100
                {
                    Console.WriteLine("Try again.");
                }
            }
            Console.WriteLine("Your numbers are:");
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(setup.GetNumbers()[j]);
            }
        }

        public void UserFoodInput(Setup setup) //ask user for their favorite foods adn puts them in userfoodlist
        {
            bool running = true;
            string food;
            string resp;
            do
            {
                Console.WriteLine("Now we're gonna need you to enter your favorite foods. Enter one now.:");
                food = Console.ReadLine();
                while (string.IsNullOrEmpty(food))
                {
                    Console.WriteLine("Enter a food.");
                    food = Console.ReadLine();
                }
                int[] numberos = setup.GetNumbers();
                setup.GetUserFood().Add(food);
                Console.WriteLine("Do you want to add another food? Y/N");
                resp = Console.ReadLine().Trim().ToUpper().Substring(0);
                while(resp != "Y" && resp != "N")
                {
                    Console.WriteLine("Do you want to add another food? Y/N");
                    resp = Console.ReadLine().Trim().ToUpper().Substring(0);
                }
                if (resp == "N")
                {
                    running = false;
                    Console.WriteLine("Thanks for your foods!");
                }
            } while (running);

            Console.WriteLine("Your foods are: ");
            for(int i = 0; i < setup.GetUserFood().Count; i++)
            {
                Console.WriteLine(setup.GetUserFood()[i]);
            }
            Console.WriteLine("\n");
        }
    }
}
