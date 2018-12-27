using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 18-APR-2018
 * Prof. Warren
 * flipflops: evil creature
 */
namespace HomeworkHanel
{
    class Flipflops: Shoes
    {
        private const int SKILL = 5; 
        public Flipflops() : base(SKILL) //creates object using base
        {

        }

        public override bool Attack() //also determines if attack kills player
        {
            if (base.IsAttackSuccessful())
            {
                Console.WriteLine("You are flipped and flopped to death!");
                return true;
            }
            else
            {
                Console.WriteLine("The creature hisses and runs away.");
                return false;
            }
        }
    }
}
