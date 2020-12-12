using System;

namespace _09.TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input ;
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commission = 0;
            // Find Procent of Commissions 
            //            0 ≤ s ≤ 500        || 500 < s ≤ 1 000     || 1 000 < s ≤ 10 000     || s > 10 000;
            // Sofia          5 %                     7 %                       8 %                 12 %
            // Varna         4.5 %                   7.5 %                     10 %                 13 %
            // Plovdiv        5.5 %                   8 %                      12 %                 14.5 %
            switch (town)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                    {
                        commission = sales * 0.05;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commission = sales * 0.07;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commission = sales * 0.08;
                    }
                    else
                    {
                        commission = sales * 0.12;
                    }
                    break;
                    ;
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        commission = sales * 0.045;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commission = sales * 0.075;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commission = sales * 0.10;
                    }
                    else
                    {
                        commission = sales * 0.13;
                    }
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        commission = sales * 0.055;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commission = sales * 0.08;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commission = sales * 0.12;
                    }
                    else
                    {
                        commission = sales * 0.145;
                    }
                    break;
            }
            // Print Output ;
            bool towns = town != "Sofia" && town != "Varna" && town != "Plovdiv"; 
            if (sales < 0 || towns)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{commission:f2}");
            }
        }
    }
}
