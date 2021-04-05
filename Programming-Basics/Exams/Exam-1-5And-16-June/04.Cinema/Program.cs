using System;

namespace _04.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallMax = int.Parse(Console.ReadLine());
            int totalMoney = 0;
            int totalPeaple = 0;

            string input = Console.ReadLine();
            while (input != "Movie time!")
            {
                int numEnter = int.Parse(input);
                totalPeaple += numEnter;
                if (totalPeaple > hallMax)
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                if (numEnter % 3 == 0)
                {
                    totalMoney += numEnter * 5;
                    totalMoney -= 5;

                }
                else
                {
                    totalMoney += numEnter * 5;
                }
                input = Console.ReadLine();
            }
            if (input == "Movie time!")
            {
                Console.WriteLine($"There are {hallMax - totalPeaple} seats left in the cinema.");
            }
            Console.WriteLine($"Cinema income - {totalMoney} lv.");
        }
    }
}
