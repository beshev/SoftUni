using System;

namespace _03.Rest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input. 
            double priceVacantoin = double.Parse(Console.ReadLine());
            double moneyHave = double.Parse(Console.ReadLine());
            int daysGoneBy = 0;
            int daysSpend = 0;
            string action = "";
            double sumSpenOrSave = 0;

            // Find whether She -> Save or Spen Money
            while ((moneyHave < priceVacantoin) && (daysSpend < 5))
            {
                daysGoneBy++;
                action = Console.ReadLine();
                sumSpenOrSave = double.Parse(Console.ReadLine());
                // Find money spend
               if (action == "spend")
                {
                    daysSpend += 1;
                    moneyHave -= sumSpenOrSave;
                    if (moneyHave < 0)
                    {
                        moneyHave = 0;
                    }
                }
                // Find money save 
                if (action == "save")
                {
                    moneyHave += sumSpenOrSave;
                    daysSpend = 0;
                }

            }
                // Find she have money for vacantion or Days Spend == 5;
                if (moneyHave >= priceVacantoin)
                {
                    Console.WriteLine($"You saved the money for {daysGoneBy} days.");
                   
                }
                if (daysSpend == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine($"{daysGoneBy}");
          
                }

        }
    }
}
