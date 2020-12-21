using System;

namespace _07.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int number = int.Parse(Console.ReadLine());

            // Find NumSum
            int sumNumber = 0;
            for (int i = 0; i < number; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                sumNumber += numbers; 
            }
            //Print Output
            Console.WriteLine(sumNumber);
        }
    }
}
