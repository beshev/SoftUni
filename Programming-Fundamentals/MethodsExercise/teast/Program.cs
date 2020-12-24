using System;

namespace teast
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 3, 6, 8, 7 };
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    Console.Write($"{array[i]}, ");
                }
            }
            Console.Write("]");

        }
    }
}
