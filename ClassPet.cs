using System;
using System.Collections.Generic;
using System.Text;

namespace tamagotchi
{
    class Pet
    {
        protected string name;
        protected uint health, /*happiness, */hunger, tiredness; //id?
        //protected static uint idcount = 0;

        public Pet() //starting values
        {
            name = Console.ReadLine();
            health = 10;
            //happiness = 10;
            hunger = 0;
            tiredness = 0;
            //id = ++idcount;
        }

        public void Resurrection()
        {

        }


        public bool GameOver() => health == 0;

        #region interactions
        public uint Feed()
        {
            if (hunger > 0)
            {
                hunger--;
                return hunger;
            }
            else
            {
                health--;
                return health;
            }
        }

        public void Sleep() //return?
        {
            tiredness = 0;
            if (health < 10)
                health++;
            if (hunger < 10)
            hunger++;
        }

        public uint Play() 
        {
            if (tiredness < 10)
            {
                tiredness++;
                return tiredness;
            }
            else
            {
                health--;
                return health;
            }
        }

        public uint Heal() => health = 10;

        #endregion

        #region output
        public string StatOutput(uint stat)
        {
            string Out = "";
            for (uint i = 0; i < stat; i++)
                Out += "+";
            for (uint i = stat; i < 10; i++)
                Out += "_";
            return Out;
        }

        public string Output()
        {
            string Out = "";
            Out += "################################################################################\n";
            for (int i  = 0; i < (80 - name.Length - 2) / 2; i++)
                Out += "#";
            Out += $" {name} ";
            for (int i = ((80 - name.Length) / 2 + 2 + name.Length); i <= 80; i++)
                Out += "#";
            Out += "\n################################################################################\n" + 
                $"####### HEALTH {StatOutput(health)}    ###################################################" +
                $"\n####### HANGER {StatOutput(hunger)}    ###################################################" +
                $"\n####### TIREDNESS {StatOutput(tiredness)} ###################################################" +
                "\n################################################################################\n";
            return Out;
        }

        #endregion

    }
}
