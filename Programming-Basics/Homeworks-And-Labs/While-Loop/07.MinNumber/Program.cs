using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string nums = Console.ReadLine();
            int minNumber = int.MaxValue;

            // Find MaxNuber
            while (nums != "Stop")
            {
                int num = int.Parse(nums);
                if (minNumber > num)
                {
                    minNumber = num;
                }
                nums = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}
