using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Bradley Hanel
 * 7-FEB-2018
 * Prof. Warren
 * Program: Main method for running Laundry Adventure
 */ 
namespace HomeworkHanel
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            Setup setup = new Setup();
            //runs setup code to get character name
            setup.GetCharacter();

            //runs introduction
            setup.Introduction();
            setup.IntegerInfo(setup);
            setup.UserFoodInput(setup);

            //runs yard code
            Yard frontyard = new Yard();
            frontyard.ExploreYard();

            //runs code when user makes it to front door
            frontyard.FrontDoor(setup);

            House yourhouse = new House();


            //runs code to start entering the house
            yourhouse.HouseIntro(setup);
            yourhouse.AnimalDealings();

            bool cont = true;
            do
            {
                cont = yourhouse.whereTo(setup);
            } while (true);

        }
    }
}