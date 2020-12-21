using System;

namespace _01.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Read Input 
            double sumLegacy = double.Parse(Console.ReadLine());
            int yearsLives = int.Parse(Console.ReadLine());
            double priceForLives = 0;
            int ivanYears = 18;

            // 2.Find the years Ivancho Must Live ;
            for (int year = 1800; year <= yearsLives; year++)
            {
                // 2.1 Find Price For this Years ;
                if (year % 2 == 0)
                {
                    priceForLives += 12000;
                }
                else
                {
                    priceForLives += 12000 + 50 * ivanYears ;  
                }
                ivanYears++;
            }
            
            // 3.Print Output
            // 3.1Find Legacy will be enough for this years ;    
            if (sumLegacy >= priceForLives)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {sumLegacy - priceForLives:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {priceForLives - sumLegacy:f2} dollars to survive.");
            }

        }
    }
}
