using System;

namespace tamagotchi
{
    class Program
    {
        static void Main()
        {
            uint action;

            Console.WriteLine("Please enter the pet's name  ");
            Pet pet = new Pet();

            do
            {
                Console.Clear();
                Console.WriteLine(pet.Output());
                Console.WriteLine("\tSelect action: \n\t1. Feed\n\t2. Sleep\n\t3. Play\n\t4. Heal");
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
                }
            } while (!pet.GameOver());
        }
    }
}
