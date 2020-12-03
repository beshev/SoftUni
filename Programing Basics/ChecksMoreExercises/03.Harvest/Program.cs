using System;

namespace _03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int Area = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int litersNeeds = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());           
            double areaStart = Area * grapes;   
            double vineLitters = (0.40 * areaStart) / 2.5;
            double litersLeft = vineLitters - litersNeeds;
            if (vineLitters < litersNeeds)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(litersNeeds - vineLitters)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(vineLitters)} liters.");
                Console.WriteLine($"{Math.Ceiling(litersLeft)} liters left -> {Math.Ceiling(litersLeft / numWorkers)} liters per person.");
            }

        }
    }
}
