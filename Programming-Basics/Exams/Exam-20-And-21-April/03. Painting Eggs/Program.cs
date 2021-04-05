using System;

namespace _03._Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string eggSize = Console.ReadLine();
            string eggColor = Console.ReadLine();
            int eggNum = int.Parse(Console.ReadLine());

            double eggSum = 0;

            switch (eggColor)
            {
                case "Red":
                    switch (eggSize)
                    {
                        case "Large":
                            eggSum = eggNum * 16;
                            break;
                        case "Medium":
                            eggSum = eggNum * 13;
                            break;
                        case "Small":
                            eggSum = eggNum * 9;
                            break;                        
                    }

                    break;
                case "Green":
                    switch (eggSize)
                    {
                        case "Large":
                            eggSum = eggNum * 12;
                            break;
                        case "Medium":
                            eggSum = eggNum * 9;
                            break;
                        case "Small":
                            eggSum = eggNum * 8;
                            break;
                    }
                    break;
                case "Yellow":
                    switch (eggSize)
                    {
                        case "Large":
                            eggSum = eggNum * 9;
                            break;
                        case "Medium":
                            eggSum = eggNum * 7;
                            break;
                        case "Small":
                            eggSum = eggNum * 5;
                            break;
                    }
                    break;
            }
            double totalSum = eggSum - (eggSum * 0.35);
            Console.WriteLine($"{totalSum:f2} leva.");
        }
    }
}
