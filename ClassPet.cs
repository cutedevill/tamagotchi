using System;
using System.Collections.Generic;
using System.Text;

namespace tamagotchi
{
    class Pet
    {
        protected string name;
        protected uint health, hunger, tiredness;

        public Pet() { }

        public void Stat_Change(string name_, uint health_ = 10, uint hunger_ = 0, uint tiredness_ = 0)
        {
            name = name_;
            health = health_;
            hunger = hunger_;
            tiredness = tiredness_;
        }

        public bool Game_Over() => health == 0;
       

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

        public uint Sleep() 
        {
            tiredness = 0;
            if (health < 10)
                health++;
            if (hunger < 10)
                hunger++;
            else
                health--;
            return tiredness;
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

        public uint Tired(uint health) //needed for heal action
        {
            if (tiredness <= 10)
                return health;
            else
            {
                tiredness = 10;;
                return health - 1;
            }                
        }

        public uint Heal()
        {
            health += 5;
            tiredness += 2;
            if (health <= 10)
            {
                Tired(health);
                return health;
            }                
            else
            {
                health = 10;
                tiredness++;
                health = Tired(health);
                return health;
            }                
        }

        #endregion

        #region output
        public string Stat_Output(uint stat)
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
                $"####### HEALTH {Stat_Output(health)}    ###################################################" +
                $"\n####### HANGER {Stat_Output(hunger)}    ###################################################" +
                $"\n####### TIREDNESS {Stat_Output(tiredness)} ###################################################" +
                "\n################################################################################\n";
            return Out;
        }
        #endregion

       // public void
    }
} 