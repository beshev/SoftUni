using System;

namespace _03._03.Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyHave = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double sum = 0;

            switch (gender)
            {
                case 'm':
                    switch (sport)
                    {
                        case "Gym":
                            sum = 42;
                            break; 
                        case "Boxing":
                            sum = 41;
                            break; 
                        case "Yoga":
                            sum = 45;
                            break; 
                        case "Zumba":
                            sum = 34;
                            break; 
                        case "Dances":
                            sum = 51;
                            break; 
                        case "Pilates":
                            sum = 39;
                            break;
                    }
                    break;
                case 'f':
                    switch (sport)
                    {
                        case "Gym":
                            sum = 35;
                            break;
                        case "Boxing":
                            sum = 37;
                            break;
                        case "Yoga":
                            sum = 42;
                            break;
                        case "Zumba":
                            sum = 31;
                            break;
                        case "Dances":
                            sum = 53;
                            break;
                        case "Pilates":
                            sum = 37;
                            break;
                    }
                    break;
            }
            if (age <= 19)
            {
                sum -= sum * 0.2;
            }
            if (sum <= moneyHave)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${sum - moneyHave:f2} more.");
            }

        }
    }
}
