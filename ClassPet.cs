using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public string State_Output(uint state)
        {
            string Out = "";
            for (uint i = 0; i < state; i++)
                Out += "+";
            for (uint i = state; i < 10; i++)
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
                $"####### HEALTH {State_Output(health)}    ###################################################" +
                $"\n####### HUNGER {State_Output(hunger)}    ###################################################" +
                $"\n####### TIREDNESS {State_Output(tiredness)} ###################################################" +
                "\n################################################################################\n";
            return Out;
        }
        #endregion


        public void Game_Log(byte option)
        {
            string prepath = @$"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..";
            string path = @$"{prepath}\{name}'s_log.txt";
            switch (option)
            {
                case 0:
                    File.WriteAllText(path, $"\n\t\t\tHere saved the {name}'s game log" +
                        $"\n\n\tAction\t\tHealth\t\t  HUnger\t   Tiredness" +
                        $"\n---------------------------------------------------------------------------" +
                        $"\n\tInitial state {State_Output(health)}\t{State_Output(hunger)}\t   {State_Output(tiredness)}" );
                    break;
                case 1:
                    File.AppendAllText(path, $"\n\n\tFeed\t      {State_Output(health)}\t{State_Output(hunger)}\t   {State_Output(tiredness)}");
                    break;
                case 2:
                    File.AppendAllText(path, $"\n\n\tSleep\t      {State_Output(health)}\t{State_Output(hunger)}\t   {State_Output(tiredness)}");
                    break;
                case 3:
                    File.AppendAllText(path, $"\n\n\tPlay\t      {State_Output(health)}\t{State_Output(hunger)}\t   {State_Output(tiredness)}");
                    break;
                case 4:
                    File.AppendAllText(path, $"\n\n\tHeal\t      {State_Output(health)}\t{State_Output(hunger)}\t   {State_Output(tiredness)}");
                    break;
                case 5:
                    File.AppendAllText(path, "\n\t\t\tYour pet has dead.");
                    break;

            }
        }

        public bool Last_Save(byte option)
        {
            string prepath = @$"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..";
            string path = @$"{Path.Combine(prepath)}\{name}'s_last_save.txt";
            switch (option)
            {
                case 0:
                    if (!File.Exists(path))
                        return false;
                     return true;
                case 1:
                    File.WriteAllText(path, $"{health} {hunger} {tiredness}");
                    return true;
                case 2:
                    StreamReader file = new StreamReader(path);
                    string values = file.ReadLine();
                    file.Close();
                    var uints = values.Split(' ').Select(UInt32.Parse).ToArray();
                    health = uints[0];
                    hunger = uints[1];
                    tiredness = uints[2];
                    return true;
                default:
                    return false;
            }
        }
    }
} 