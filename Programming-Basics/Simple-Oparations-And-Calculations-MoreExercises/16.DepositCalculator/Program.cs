using System;

namespace _16.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            percentage /= 100;
                
            double interest = deposit * percentage;
            interest /= 12;
            double sum = deposit + (term * interest);
            Console.WriteLine(sum);

          


           
        }
    }
}
