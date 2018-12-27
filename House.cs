using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
/*
 * Bradley Hanel
 * 21-FEB-2018
 * Prof. Warren
 * house: runs program while user is in the house
 */
namespace HomeworkHanel
{
    class House
    {
        Dungeon basement = new Dungeon();
        Yard frontyard = new Yard();
        string response;
        public void HouseIntro(Setup setup) //begins code for once the user enters the house -- introduces the animals
        {
            const string MY_COLORS = "red,orange,yellow,green,blue,indigo,violet,black";

            int comma2 = (MY_COLORS.IndexOf(',', MY_COLORS.IndexOf(',') + 1)) + 1;
            int comma3 = MY_COLORS.IndexOf(',', comma2) - (comma2);
            string color3 = MY_COLORS.Substring(comma2, comma3); //code for searching for 3rd color is MY_COLORS

            Console.WriteLine("When the door opens, there is a shining " + color3 + " object in front of you.");

            //Once you go in the door, you'll he in a hallway with 5 rooms. Two rooms to the north are the dining room and living room. Three rooms to the south are the kitchen and two bedrooms. You're suddenly filled with boredom and you long for a quest.
            Console.WriteLine(" \n\n You peer into the door. It's your house, you've been here a million times before, but here's a decription \n");
            Console.WriteLine("Alright.");
            Console.WriteLine("To your left is your dining room, and the living room is a little bit down the hallway.");
            Console.WriteLine("To your right is your kitchen, with a big refrigerator in it. There's also your bedroom, and your brother's bedroom.");
            Console.WriteLine("Every room in your house is full of dirty laundry. Did you forget to do the laundry again?");

            Sweatshirt.AnimalGreeting();

            string[] SSColor = new string[5];
            string[] SSLogo = new string[5];
            int[] SSLegs = new int[10];
            int[] SSStains = new int[10];

            SSColor[0] = "red";
            SSColor[1] = "orange";
            SSColor[2] = "yellow";
            SSColor[3] = "green";
            SSColor[4] = "black";

            SSLogo[0] = "RIT";
            SSLogo[1] = "I <3 Spiders";
            SSLogo[2] = "Sweatshirt";
            SSLogo[3] = "NTID";
            SSLogo[4] = "MCC";

            for (int i = 0; i < 10; i++)
            {
                SSLegs[i] = i;
                SSStains[i] = i;
            }

            Random rgen = new Random();
            Sweatshirt s1 = new Sweatshirt();
            s1.setColor(SSColor[rgen.Next(0,4)]);
            s1.setHealth(50);
            s1.setLogo(SSLogo[rgen.Next(0, 4)]);
            s1.setLegs(setup.GetNumbers()[rgen.Next(0, 4)]);
            s1.setStains(SSStains[rgen.Next(0, 9)]);

            Sweatshirt s2 = new Sweatshirt();
            s2.setColor(SSColor[rgen.Next(0, 4)]);
            s2.setHealth(50);
            s2.setLogo(SSLogo[rgen.Next(0, 4)]);
            s2.setLegs(setup.GetNumbers()[rgen.Next(0, 4)]);
            s2.setStains(SSStains[rgen.Next(0, 9)]);

            Console.WriteLine("The first sweatshirt is " + s1.getColor() + ", with " + s1.getLogo() + " printed on the front. It has " + s1.getStains() + " stains, and " + s1.getLegs() + " legs.");
            Console.WriteLine("The second sweatshirt is " + s2.getColor() + ", with " + s2.getLogo() + " printed on the front. It has " + s2.getStains() + " stains, and " + s2.getLegs() + " legs.");
            Console.WriteLine("How did they get so many legs? Remember when we asked you for numbers? wow this game is interactive yay");
        }

        public void AnimalDealings() //code for interaction with animals
        {
            int deal;
            Console.WriteLine("Press 1 to spare them, 2 to kill them, and 3 to quit.");
            while ((!int.TryParse(Console.ReadLine(), out deal)) || deal > 3 || deal < 1) //checks to make sure the user actually input a number 1-3
            {
                Console.WriteLine("Try again.");
            }
            if(deal == 1)
            {
                Console.WriteLine("You spare the sweatshirts.");
            }
            else if(deal == 2)
            {
                Console.WriteLine("Despite them not having faces, the sweatshirts look at you with a cute yet sad expression. Are you sure? Y/N");
                string response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Substring(0, 1);
                    response = response.ToUpper();
                }
                while (response != "N" && response != "Y")
                {
                    Console.WriteLine("They stare cuter.");
                    response = Console.ReadLine();
                    if (!string.IsNullOrEmpty(response))
                    {
                        response = response.Substring(0, 1);
                        response = response.ToUpper();
                    }
                }
                //checks response for Y or N and responds accordingly
                if (response == "Y")
                {
                    Console.WriteLine("You monster. \n The sweatshirts are dead.");
                }
                else if (response == "N")
                {
                    Console.WriteLine("You spare the sweatshirts.");
                }
            }
            else
            {
                Config.GameEnd();
            }

        }

        public bool whereTo(Setup setup) //comes back to this code every time the user goes back to the front door. brings them to the right room
        {
            Console.WriteLine("Where do you want to go now? \n 1 - Kitchen \n 2 - Dining Room \n 3 - Your room \n 4 - Your brother's room \n 5 - Living Room \n 6 - Back to yard");
            string room;
            bool loop = true;
            while (loop)
            {
                room = Console.ReadLine();
                switch (room)
                {
                    case "1":
                        searchKitchen(setup);
                        loop = false;
                        break;
                    case "2":
                        searchDining();
                        loop = false;
                        break;
                    case "3":
                        searchBedroom();
                        loop = false;
                        break;
                    case "4":
                        searchBedroom2();
                        loop = false;
                        break;
                    case "5":
                        searchLiving();
                        loop = false;
                        break;
                    case "6":
                        frontyard.ExploreYard();
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Room unavailable.");
                        break;
                }
                
            }
            return true;







        }


        public void searchKitchen(Setup setup) //code for searching kitchen, also accesses food list to display which foods are in the kitchen
        {
            Random rgen = new Random();
            Console.WriteLine("You are in the kitchen. You see a refrigerator and a cabinet.");
            Console.WriteLine("If you open the cabinet, you'll find it's full of " + setup.GetUserFood()[rgen.Next(0, setup.GetUserFood().Count)] + ".");
            Thread.Sleep(1001);
            Console.WriteLine("Inside the refrigerator, there is a bucket of " + setup.GetUserFood()[rgen.Next(0, setup.GetUserFood().Count)]  + " right next to a bucket of Tide Pods");
            Thread.Sleep(1001);
            Console.WriteLine("The counters are covered in " + setup.GetUserFood()[rgen.Next(0, setup.GetUserFood().Count)] + ".");
            Console.WriteLine("The floor is covered in laundry.");
            Console.WriteLine("Continue exploring? (Y/N)");

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
            }
            else if (response == "N")
            {
                Config.GameEnd();
            }
        }
        public void searchDining() //code for searching dining
        {
            Console.WriteLine("You are in the dining room. Not too much exciting here, just a big table. It has been neatly set for dinner. The floor is convered in laundry.");
            Console.WriteLine("Continue exploring? (Y/N)");

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
            }
            else if (response == "N")
            {
                Config.GameEnd();
            }
        }
        public void searchBedroom() //code for searching bedroom
        {
            Console.WriteLine("You are in your room. You see your bed, unruly and unmade. You see your dresser, unused since 2006. When was the last time you cleaned this room? The floor is covered in laundry.");
            Console.WriteLine("Continue exploring? (Y/N)");

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
            }
            else if (response == "N")
            {
                Config.GameEnd();
            }
        } 
        public void searchBedroom2() //code for searching bedroom 2
        {
            Console.WriteLine("You are in your brother's room. He has a large 'DO NOT ENTER' banner above his door. His desk is neat and cleaned, his bed is made, but the floor is covered in laundry.");
            Console.WriteLine("Continue exploring? (Y/N)");

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
            }
            else if (response == "N")
            {
                Config.GameEnd();
            }
        }
        public void searchLiving() //code for searching living room
        {
            Console.WriteLine("You are in the living room. In it is a trophy case, a TV, and a couch. All are neatly dusted and vacuumed. There is a door in this room leading to the basement, you hear a loud machine noise coming from it. The floor is covered in laundry.");
            Console.WriteLine("What would you like to do? \n 1-walk down the stairs \n 2-close the door and pretend it's not there. \n 3-cry \n 4-quit");

            int deal;
            while ((!int.TryParse(Console.ReadLine(), out deal)) || deal > 4 || deal < 1) //checks to make sure the user actually input a number 1-4
            {
                Console.WriteLine("Try again.");
            }
            if (deal == 1)
            {
                basement.DungeonFirstArea();
            }
            else if (deal == 2)
            {
                Console.WriteLine("I was really banking on you going down those stairs. Are you sure? Y/N");
                string response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Substring(0, 1);
                    response = response.ToUpper();
                }
                //checks response for Y or N and responds accordingly
                if (response == "Y")
                {
                    Console.WriteLine("Well alright, then I have nothing for you.");
                    Config.GameEnd();
                }
                else if (response == "N")
                {
                    basement.DungeonFirstArea();
                }
                else
                {
                    Console.WriteLine("Just leave.");
                    Config.GameEnd();
                }
            }
            else if (deal == 3)
            {
                Console.WriteLine("Yeah, me too. \n");
                Console.WriteLine("A voice beckons you downward, and in your melancholy, you follow it to the basement.");
                basement.DungeonFirstArea();
            }
            else
            {
                Config.GameEnd();
            }
        }




        

        //When you go back in the hallway, you can then go to the kitchen. Go there to get the tide pods, they will be in the fridge, but don't eat them. You will die.

        //Go back in the hallway again and go to the next room, your bedroom. You will need to find all the laundry, which is under your bed, behind your desk, and in your hamper.

        //After you get all your laundry, go to the second bedroom. It's your brother's room. Ask him for a dryer sheet and he'll give you one.

        //The next room is the living room. In the living room is the stairs to the basement. Go down to the basement.
    }
}
