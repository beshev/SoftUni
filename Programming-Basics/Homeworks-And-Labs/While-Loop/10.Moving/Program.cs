using System;

namespace _10.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int boxSpace = 0;
            // find free space
            int freeSpace = width * length * height;

            // find Space For Boxes
            string input = Console.ReadLine();
            while (input != "Done" )
            {
                boxSpace += int.Parse(input);
                // If free Space is over;
                if (freeSpace < boxSpace)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace - boxSpace)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
                

            }
            if (input == "Done")
            {
                Console.WriteLine($"{freeSpace - boxSpace} Cubic meters left.");
            }
        }
    }
}
