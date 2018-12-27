using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 23-FEB-2018
 * Prof. Warren
 * Sweatshirt: 
 */
namespace HomeworkHanel
{
    public class Sweatshirt
    {
        int sleeves;
        int stains;
        string logo;
        string color;
        int health;

        public static void AnimalGreeting() //greeted by the animals created in the house class
        {
            Console.WriteLine("As you ponder this question, two dirty sweatshirts come up to greet you. You are shocked to see they've become sentient.");

        }

        //methods for setting "animal" attributes
        public void setLegs(int sleevies)
        {
            sleeves = sleevies;
        }
        public void setStains(int stain)
        {
            stains = stain;
        }
        public void setLogo(string screenprint)
        {
            logo = screenprint;
        }
        public void setHealth(int hearts)
        {
            health = hearts;
        }
        public void setColor(string colour)
        {
            color = colour;
        }

        //methods for getting "animal" attributes
        public int getLegs()
        {
            return sleeves;
        }
        public int getStains()
        {
            return stains;
        }
        public string getLogo()
        {
            return logo;
        }
        public string getColor()
        {
            return color;
        }
        public int getHealth()
        {
            return health;
        }

        

    }
}
