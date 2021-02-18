using System;
using System.Collections.Generic;
using System.IO;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenWindow = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                int currentGreenWindow = greenWindow;
                int currentFreeWindow = freeWindow;
                if (input == "green")
                {
                    while (cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();
                        if (currentCar.Length < currentGreenWindow)
                        {
                            currentGreenWindow -= currentCar.Length;
                            carsPassed++;
                        }
                        else if (currentCar.Length == currentGreenWindow)
                        {
                            carsPassed++;
                            break;
                        }
                        else
                        {
                            int leftWindow = currentFreeWindow + currentGreenWindow;
                            if (currentCar.Length <= leftWindow)
                            {
                                carsPassed++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[leftWindow]}.");
                                return;
                            }
                        }

                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
