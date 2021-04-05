using System;

namespace _04._02.Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());


            string actorName = Console.ReadLine();
            while (actorName != "ACTION")
            {
                if (actorName.Length > 15)
                {
                    budget -= budget * 0.2;
                }
                else
                {
                    double priceForActor = double.Parse(Console.ReadLine());
                    budget -= priceForActor;
                }
                
                if (budget <= 0)
                {
                    Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
                    return;
                }                          
                actorName = Console.ReadLine();
            }
            Console.WriteLine($"We are left with {budget:f2} leva.");
        }
    }
}
