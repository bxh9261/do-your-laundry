using System;
using System.Collections.Generic;
using System.Text;
/*
 * Bradley Hanel
 * 18-APR-2018
 * Prof. Warren
 * shoes: evil creature
 */
namespace HomeworkHanel
{
    abstract class Shoes
    {
        private int attackSkill;

        public Shoes(int attack) //creats a Shoes
        {
            attackSkill = attack;
        }
        public abstract bool Attack();
        public virtual bool IsAttackSuccessful() //determines if attack kills player
        {
            Random rgen = new Random();
            int die = rgen.Next(1, 7);
            if (attackSkill >= die)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
