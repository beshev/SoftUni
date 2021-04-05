using System;

namespace _7.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            for (int i = 0; i < n; i++)
            {
                int littersAdd = int.Parse(Console.ReadLine());
                if (littersAdd <= tankCapacity)
                {
                    tankCapacity -= littersAdd;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(255 - tankCapacity);
        }
    }
}
