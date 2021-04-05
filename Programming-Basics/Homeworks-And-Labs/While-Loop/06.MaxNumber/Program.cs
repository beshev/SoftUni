using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string nums = Console.ReadLine();
            int maxNumber = int.MinValue;

            // Find MaxNuber
            while (nums != "Stop")
            {
                int num = int.Parse(nums);
                if (maxNumber < num)
                {
                    maxNumber = num;
                }
                nums = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
