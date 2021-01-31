using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int light = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();
            string input = Console.ReadLine();
            int counter = 0;
            while (input != "END")
            {
                if (input == "green")
                {
                    int greenLight = light;
                    int freeWindow = window;
                    while (carsQueue.Count > 0)
                    {
                        if (greenLight > 0)
                        {

                            string currentCar = carsQueue.Peek();
                            if (currentCar.Length <= greenLight)
                            {
                                greenLight -= currentCar.Length;
                                currentCar = currentCar.Remove(0);
                            }
                            else
                            {
                                currentCar = currentCar.Remove(0, greenLight);
                                greenLight = 0;
                            }
                            if (currentCar == "")
                            {
                                carsQueue.Dequeue();
                                counter++;
                            }
                            else
                            {
                                if (currentCar.Length <= window)
                                {
                                    carsQueue.Dequeue();
                                    counter++;
                                }
                                else
                                {
                                    currentCar = currentCar.Remove(0, window);
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{carsQueue.Dequeue()} was hit at {currentCar[0]}.");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }

    }
}
