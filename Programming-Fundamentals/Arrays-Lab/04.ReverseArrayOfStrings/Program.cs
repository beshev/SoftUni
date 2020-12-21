using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine().Split();
            for (int i = 0; i < arrays.Length / 2; i++)
            {
                string temp = arrays[i];
                arrays[i] = arrays[arrays.Length - 1 - i];
                arrays[arrays.Length - 1 - i] = temp;             
            }
            foreach (var item in arrays)
            {
                Console.Write(item + " ");
            }

        }
    }
}
