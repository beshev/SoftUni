using System;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggNum = int.Parse(Console.ReadLine());
            int counterRed = 0;
            int counterOrange = 0;
            int counterBlue = 0;
            int counterGreen = 0;
            int maxNum = int.MinValue;
            string color = "";

            for (int eggPaint = 1; eggPaint <= eggNum; eggPaint++)
            {
                string eggColor = Console.ReadLine();
                switch (eggColor)
                {
                    case "red":
                        counterRed++;
                        if (maxNum < counterRed)
                        {
                            maxNum = counterRed;
                            color = "red";
                        }
                        break;
                    case "orange":
                        counterOrange++;
                        if (maxNum < counterOrange)
                        {
                            maxNum = counterOrange;
                            color = "orange";
                        }
                        break;
                    case "blue":
                        counterBlue++;
                        if (maxNum < counterBlue)
                        {
                            maxNum = counterBlue;
                            color = "blue";
                        }
                        break;
                    case "green":
                        counterGreen++;
                        if (maxNum < counterGreen)
                        {
                            maxNum = counterGreen;
                            color = "green";
                        }
                        break;
                }
                              
            }
            Console.WriteLine($"Red eggs: {counterRed}");
            Console.WriteLine($"Orange eggs: {counterOrange}");
            Console.WriteLine($"Blue eggs: {counterBlue}");
            Console.WriteLine($"Green eggs: {counterGreen}");
            Console.WriteLine($"Max eggs: {maxNum} -> {color}");
        }
    }
}
