using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyWanna = double.Parse(Console.ReadLine());
            double totalSum = 0;

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                int coctailOrder = int.Parse(Console.ReadLine());
                double sum = 0;
                sum = coctailOrder * input.Length;
                if (sum % 2 != 0)
                {
                    sum -= sum * 0.25;
                    totalSum += sum;
                }
                else
                {
                    totalSum += input.Length * coctailOrder;
                }
                if (totalSum >= moneyWanna)
                {
                    Console.WriteLine($"Target acquired.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Party!")
            {
                Console.WriteLine($"We need {moneyWanna - totalSum:f2} leva more.");
            }
            Console.WriteLine($"Club income - {totalSum:f2} leva.");
        }
    }
}
