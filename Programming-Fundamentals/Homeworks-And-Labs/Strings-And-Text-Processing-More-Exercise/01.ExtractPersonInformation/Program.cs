using System;
using System.Linq;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int firstIndexOfName = text.IndexOf('@');
                int lastIndexOfName = text.IndexOf('|');
                string name = text.Substring(firstIndexOfName + 1, lastIndexOfName - firstIndexOfName - 1);

                int firstIndexOfAge = text.IndexOf('#');
                int lastIndexOfAge = text.IndexOf('*');
                string age = text.Substring(firstIndexOfAge + 1, lastIndexOfAge - firstIndexOfAge - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
