using System;

namespace _3.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeaple = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());
            byte counter = 0;
            while (numberOfPeaple > 0)
            {
                counter++;
                numberOfPeaple -= capacityOfElevator;
            }
            Console.WriteLine(counter);
            // Another Way to Slove Problem :
            //int courses = (int)Math.Ceiling((double)numberOfPeaple / capacityOfElevator);
            //Console.WriteLine(courses);

        }
    }
}
