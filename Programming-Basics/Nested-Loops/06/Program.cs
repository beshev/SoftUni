using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int numFloors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            
            for (int floor = numFloors; floor >= 1; floor--)
            {
                for (int numRoom = 0; numRoom < rooms; numRoom++)
                {
                    // Check if floor is last or Only one || Check Of floor is Even Or Odd:
                    if (numFloors == floor)
                    {
                        Console.Write($"L{numFloors}{numRoom} ");
                    }
                    // Check Of floor is Even Or Odd:
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{numRoom} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{numRoom} ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
