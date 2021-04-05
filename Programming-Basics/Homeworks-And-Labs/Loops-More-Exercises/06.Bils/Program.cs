using System;

namespace _06.Bils
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            int months = int.Parse(Console.ReadLine());
            double moneyWater = 0;
            double moneyInternet = 0;
            double moneyOthers = 0;
            double electry = 0;
            double average = 0;
            double others = 0;
            for (int i = 0; i < months; i++)
            {
                // Money For Current
                double currentPrice = double.Parse(Console.ReadLine());
                // Money For Bilds of every Month
                electry += currentPrice;               
                moneyInternet += 15;
                moneyWater += 20;
                moneyOthers = currentPrice + 20 + 15;
                moneyOthers += (moneyOthers * 0.20);
                others += moneyOthers;

            }          
            average += moneyInternet + moneyWater + electry + others;
            // Average money for all months
            average /= months;
            // Output
            Console.WriteLine($"Electricity: {electry:F2} lv");
            Console.WriteLine($"Water: {moneyWater:F2} lv");
            Console.WriteLine($"Internet: {moneyInternet:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");




        }
    }
}
