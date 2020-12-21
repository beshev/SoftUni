using System;

namespace _04._01Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGroups = int.Parse(Console.ReadLine());
            double counterMusala = 0;
            double counterMonbla = 0;
            double counterKilimangaro = 0;
            double counterK2 = 0;
            double counterEverest = 0;
            double totalPeople = 0;
            for (int i = 0; i < numGroups; i++)
            {
                int numPeople = int.Parse(Console.ReadLine());
                totalPeople += numPeople;
                if (numPeople <= 5)
                {
                    counterMusala += numPeople;
                }
                else if (numPeople <= 12)
                {
                    counterMonbla += numPeople;
                }
                else if (numPeople <= 25)
                {
                    counterKilimangaro += numPeople;
                }
                else if (numPeople <= 40)
                {
                    counterK2 += numPeople;
                }
                else
                {
                    counterEverest += numPeople;
                }
            }
            Console.WriteLine($"{(counterMusala / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(counterMonbla / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(counterKilimangaro / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(counterK2 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(counterEverest / totalPeople) * 100:f2}%");
        }
    }
}
