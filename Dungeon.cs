using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 21-FEB-2018
 * Prof. Warren
 * Dungeon: runs program while user is in the basement
 */
namespace HomeworkHanel
{
    class Dungeon
    {
        public void DungeonFirstArea() //code for first dungeon area
        {
            Console.WriteLine("You walk down the stairs. You notice that the washing machine is sputtering, and all the clothes that come out of it are alive! \n");
            Console.WriteLine("You remember that you forgot to do your laundry. Oh no! That must be the cause of this! \n");
            Console.WriteLine("While realizing your guilt, your exit is blocked off by shirts coming to attack you. You see another exit, but how will you escape your attackers? \n");
            Console.WriteLine("You could (T)hrow a tide pod, (S)cream really loud, or (Q)uit.");
            string response;
            bool loop = true;
            while (loop)
            {
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Trim().Substring(0, 1).ToUpper();
                }
                switch (response)
                {
                    case "T":
                        Console.WriteLine("You throw a tide pod, and your attackers run over to eat it. As they run towards you you escape to the next room.");
                        loop = false;
                        DungeonSecondArea();
                        break;
                    case "S":
                        Console.WriteLine("It's no use. \n You are dead.");
                        loop = false;
                        Config.GameEnd();
                        break;
                    case "Q":
                        loop = false;
                        Config.GameEnd();
                        break;
                    default:
                        Console.WriteLine("There's nothing your evil sentient laundry hates more than those who don't follow directions.");
                        break;
                }
            }

        }

        public void DungeonSecondArea() //code for 2nd dungeon area
        {
            Flipflops flippy = new Flipflops();
            Crocs gator = new Crocs();
            Random rgen = new Random();
            int shoe = rgen.Next(1, 3);
            Console.WriteLine("You walk into the next room. Suddenly you are pantsed! \n");
            Console.WriteLine("The culprit? None other than all your pairs of pants, and they have blocked off the exit.  \n");
            Console.WriteLine("To escape, you could try (L)int rolling them, using (F)abric softener, or you can (Q)uit.");
            string response;
            bool loop = true;
            while (loop)
            {
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Trim().Substring(0, 1).ToUpper();
                }
                switch (response)
                {
                    case "F":
                        Console.WriteLine("The pants cower in fear at the fabric softener.");
                        loop = false;
                        break;
                    case "L":
                        Console.WriteLine("The pants are glad that they will now be clean and lint free when they kill you. \n You are dead.");
                        loop = false;
                        Config.GameEnd();
                        break;
                    case "Q":
                        loop = false;
                        Config.GameEnd();
                        break;
                    default:
                        Console.WriteLine("There's nothing your evil sentient laundry hates more than those who don't follow directions.");
                        break;
                }
            }
            if (shoe == 1)
            {
                Console.WriteLine("You've encountered a hostile flip flop!");
                
            }
            else
            {
                Console.WriteLine("You've encountered a hostile croc!");
                
            }
            Console.WriteLine("What do you want to do? \n (H)it it with stick, (T)ouch it, (Q)uit");
            loop = true;
            while (loop)
            {
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Trim().Substring(0, 1).ToUpper();
                }
                switch (response)
                {
                    case "H":
                        Console.WriteLine("You've killed it.");
                        loop = false;
                        DungeonThirdArea();
                        break;
                    case "T":
                        if (shoe == 1)
                        {
                            if (flippy.Attack())
                            {
                                Config.GameEnd();
                            }
                        }
                        else
                        {
                            if (gator.Attack())
                            {
                                Config.GameEnd();
                            }
                        }
                        loop = false;
                        DungeonThirdArea();
                        break;
                    case "Q":
                        loop = false;
                        Config.GameEnd();
                        break;
                    default:
                        Console.WriteLine("There's nothing your evil sentient laundry hates more than those who don't follow directions.");
                        break;
                }
            }

        }

        public void DungeonThirdArea() //code for 3rd dungeon area
        {
            Console.WriteLine("You enter the hall of lost socks. They are very angry at you for seperating them from their partners. \n");
            Console.WriteLine("They move in for attack, but you see another exit. How will you escape?  \n");
            Console.WriteLine("You could (T)ake off your shoes, (P)unch the socks, or you can (Q)uit.");
            string response;
            bool loop = true;
            while (loop)
            {
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Trim().Substring(0, 1).ToUpper();
                }
                switch (response)
                {
                    case "T":
                        Console.WriteLine("The socks all try to get into your shoes. You run into the next room.");
                        loop = false;
                        DungeonFourthArea();
                        break;
                    case "P":
                        Console.WriteLine("There are too many of them. You are overtaken by socks. \n You are dead.");
                        loop = false;
                        Config.GameEnd();
                        break;
                    case "Q":
                        loop = false;
                        Config.GameEnd();
                        break;
                    default:
                        Console.WriteLine("There's nothing your evil sentient laundry hates more than those who don't follow directions.");
                        break;
                }
            }
        }

        public void DungeonFourthArea() //code for 4th dungeon area
        {
            Console.WriteLine("There is a large assortment of clothes in this room, and they're all angry that you never cleaned them. \n");
            Console.WriteLine("They move in for attack, but you see another exit. How will you escape?  \n");
            Console.WriteLine("You could push them into the (W)ashing machine or (F)urnace, or you can (Q)uit.");
            string response;
            bool loop = true;
            while (loop)
            {
                response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    response = response.Trim().Substring(0, 1).ToUpper();
                }
                switch (response)
                {
                    case "W":
                        Console.WriteLine("The clothes get washed. They are grateful for now being clean. You did your laundry! \n");
                        Console.WriteLine("You've escaped!.");
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
                        loop = false;
                        break;
                    case "F":
                        Console.WriteLine("You push your clothes in the furnace, but they pull you in with them. \n You are dead.");
                        loop = false;
                        Config.GameEnd();
                        break;
                    case "Q":
                        loop = false;
                        Config.GameEnd();
                        break;
                    default:
                        Console.WriteLine("There's nothing your evil sentient laundry hates more than those who don't follow directions.");
                        break;
                }
            }
        }
        //When you enter the basement, you realize that nobody has done the laundry in so long that the laundry has all come to life. The laundry blocks off the exit so you can't escape.

        //On the first level of the basement, you face the shirts. In order to defeat them, you need to throw a tide pod to the side so they all hungrily chase it. Then while they're distracted you can pass.

        //On the second level you face the pants. Hold out a dryer sheet and they'll cower in fear away from you.

        //The third level is the hall of lost socks. You need to sacrifice your shoes in order to be allowed to pass.

        //On the last level, the laundry you brought downstairs turns against you. You have to lead them into the basement furnace without getting pushed in yourself. After you've defeated your clothes, you can escape and you win!

        //Display winning message!
    }
}
