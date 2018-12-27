using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 18-APR-2018
 * Prof. Warren
 * crocs: evil creature
 */
namespace HomeworkHanel
{
    class Crocs: Shoes
    {
        const int SKILL = 2;

        public Crocs() : base(SKILL) //creates object using base
        {
        }

        public override bool Attack() //also determines if attac kkills player
        {
            if(base.IsAttackSuccessful())
            {
                Console.WriteLine("You are eaten by crocs!");
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
