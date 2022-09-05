using System;


namespace tamagotchi
{
    class Program
    {
        static void Main()
        {
            uint action;
            bool selected = false, game = true;
            Pet pet = new Pet();

            Console.Write("################################################################################\n" +
               "######################## Wellcome to the Tamagotci game ########################\n");

            do
            {
                do
                {
                    Console.Write("################################################################################\n" +
                       "####### Select option:    ######################################################\n" +
                       "####### 1. Start new game ######################################################\n" +
                       "####### 2. Load last save ######################################################\n" +
                       "####### 3. Exit           ######################################################\n" +
                       "################################################################################\n\n\t");
                    action = Convert.ToByte(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("################################################################################\n" +
                                "####### Please enter pet's name ################################################\n" +
                                "################################################################################\n\n\t");
                            pet.Stat_Change(Console.ReadLine());
                            pet.Game_Log(0);
                            pet.Last_Save(1);
                            selected = true;
                            break;
                        case 2:
                            Console.Clear();
                            bool finded = false;
                            do
                            {
                                Console.Write("################################################################################\n" +
                                    "####### Please enter pet's name ################################################\n" +
                                    "################################################################################\n\n\t");
                                pet.Stat_Change(Console.ReadLine());
                                if (pet.Last_Save(0))
                                    finded = true;
                                else
                                {
                                    Console.Write("Cann't find pet with this nsme. Please press any key to continue\n\n\t");
                                    Console.ReadKey();
                                    Console.Clear();
                                }                                
                            } while (!finded);
                            pet.Last_Save(2);
                            selected = true;
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("################################################################################\n" +
                                "################################ See you later #################################\n" +
                                "################################################################################\n");
                            return;
                        default:
                            Console.Write("Wrong value. Please press any key to continue\n\n\t");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                } while (!selected);

                do
                {
                    pet.Last_Save(1);
                    Console.Clear();
                    Console.WriteLine(pet.Output());
                    Console.Write("\tSelect action: \n\t1. Feed\n\t2. Sleep\n\t3. Play\n\t4. Heal\n\t5.Exit\n\n\t");
                    action = Convert.ToByte(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            Console.Clear();
                            pet.Feed();
                            pet.Output();
                            pet.Game_Log(1);
                            break;
                        case 2:
                            Console.Clear();
                            pet.Sleep();
                            pet.Output();
                            pet.Game_Log(2);
                            break;
                        case 3:
                            Console.Clear();
                            pet.Play();
                            pet.Output();
                            pet.Game_Log(3);
                            break;
                        case 4:
                            Console.Clear();
                            pet.Heal();
                            pet.Output();
                            pet.Game_Log(4);
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("################################################################################\n" +
                                "################################ See you later #################################\n" +
                                "################################################################################\n");
                            return;
                        default:
                            Console.WriteLine("\tWrong value. Please press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                } while (!pet.Game_Over());

                Console.Write("################################################################################\n" +
                   "##############################  Your pet has dead. ##############################\n");
                pet.Game_Log(5);

            } while (game);
        }
    }
}