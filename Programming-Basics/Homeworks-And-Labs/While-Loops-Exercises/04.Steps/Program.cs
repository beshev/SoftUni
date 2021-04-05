using System;

namespace _04.Steps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Inut
            int stepsWalk = 0;
            string step = Console.ReadLine();
            while (step != "Going home")
            {
                stepsWalk += int.Parse(step);
                // Find if we reach the Target
                if (stepsWalk >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsWalk - 10000} steps over the goal!");
                    break;
                }
                step = Console.ReadLine();

            }
            if (step == "Going home")
            {
                step = Console.ReadLine();
                stepsWalk += int.Parse(step);
                // Find If wi reach the target when we go home
                if (stepsWalk >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsWalk - 10000} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{10000 - stepsWalk} more steps to reach goal.");
                }

            }


        }
    }
}
