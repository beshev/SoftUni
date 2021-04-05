using System;
using System.Text;

namespace _07
{
    class Program
    {
        static string RepeatingString(string names, int repeatTimes) 
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < repeatTimes; i++)
            {
                result.Append(names);
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            string someString = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatingString(someString, repeatTimes));
        }
    }
}
