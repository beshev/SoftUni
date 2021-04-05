using System;

namespace ProjectPreperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string archName = Console.ReadLine();
            int projectNumb = int.Parse(Console.ReadLine());
            int workHours = projectNumb * 3;

            Console.WriteLine($"The architect {archName} will need {workHours} hours to complete {projectNumb} " +
                $"project/s.");
            
        }
    }
}
