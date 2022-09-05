using System;


namespace tamagotchi
{
    class Program
    {
        static void Main()
        {
            uint action;
            bool selected = false;
            bool game = true;
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
                            selected = true;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\nPlease enter pet's name 2\n"); ///
                            pet.Stat_Change(Console.ReadLine());
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
                            break;
                        case 2:
                            Console.Clear();
                            pet.Sleep();
                            pet.Output();
                            break;
                        case 3:
                            Console.Clear();
                            pet.Play();
                            pet.Output();
                            break;
                        case 4:
                            Console.Clear();
                            pet.Heal();
                            pet.Output();
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
                            //System.Threading.Thread.Sleep(5000);
                            break;
                    }
                } while (!pet.Game_Over());

                Console.Write("################################################################################\n" +
                   "##############################  Your pet is dead. ##############################\n");
            } while (game);
        }
    }
}