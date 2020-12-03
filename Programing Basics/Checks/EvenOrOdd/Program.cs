using System;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int even = int.Parse(Console.ReadLine());
            int evenScore = even % 2;

            if (evenScore == 0)
            {
                Console.WriteLine("even");

            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
