using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input:
            string destination = Console.ReadLine();
            double moneyHave = 0;
            while (destination != "End")
            {
                // money needed for travel:
                double moneyNeed = double.Parse(Console.ReadLine());
                // Money save:
                while (true)
                {
                    double moneySave = double.Parse(Console.ReadLine());
                    moneyHave += moneySave;
                    if (moneyHave >= moneyNeed)
                    {
                        moneyHave = 0;
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }


                }
               
                destination = Console.ReadLine();
            }
        }
    }
}
