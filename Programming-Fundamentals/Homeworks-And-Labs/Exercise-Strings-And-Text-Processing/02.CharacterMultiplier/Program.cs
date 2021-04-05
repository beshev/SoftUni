using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Console.WriteLine(CharacterMultiplier(input[0], input[1]));
        }

        static int CharacterMultiplier(string str1 , string str2)
        {
            int sum = 0;
            int iteratios = Math.Min(str1.Length, str2.Length);
            for (int i = 0; i < iteratios; i++)
            {
                sum += str1[i] * str2[i];
            }
            int compare = str1.Length.CompareTo(str2.Length);
            if (compare == 1)
            {
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sum += str1[i];
                }
            }
            else if (compare == -1)
            {
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sum += str2[i];
                }
            }
            return sum;
        }
    }
}
