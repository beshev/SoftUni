using System;

namespace _02.AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input ;
            string animal = Console.ReadLine();
            // Find class of animal
            if (animal == "crocodile" || animal == "tortoise" || animal == "snake")
            {
                Console.WriteLine("reptile");
            }
            else if (animal == "dog")
            {
                Console.WriteLine("mammal");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
