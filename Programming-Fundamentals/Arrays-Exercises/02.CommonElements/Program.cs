using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();
            string equalWords = "";
            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < array1.Length; j++)
                {
                    if (array2[i] == array1[j])
                    {
                        equalWords += array2[i] + " ";
                    }
                }
            }
            Console.WriteLine(equalWords);

        }
    }
}
