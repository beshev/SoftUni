using System;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result = array[i] ^ result;
            }
            Console.WriteLine(result);
        }
    }
}
