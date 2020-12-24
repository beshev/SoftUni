using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input == "string")
            {
                string values1 = Console.ReadLine();
                string values2 = Console.ReadLine();
                Console.WriteLine(GetMax(values1, values2));
            }
            else if (input == "int")
            {
                int values1 = int.Parse(Console.ReadLine());
                int values2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(values1, values2));
            }
            else if (input == "char")
            {
                char values1 = char.Parse(Console.ReadLine());
                char values2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(values1, values2));
            }
        }
        static string GetMax(string values1, string values2)
        {
            int result = values1.CompareTo(values2);
            if (result > 0)
            {
                return values1;
            }
            else
            {
                return values2;
            }
        }
        static int GetMax(int values1, int values2)
        {
            int result = values1.CompareTo(values2);
            if (result > 0)
            {
                return values1;
            }
            else 
            {
                return values2;
            }
        }
        static char GetMax(char values1, char values2)
        {
            int result = values1.CompareTo(values2);
            if (result > 0)
            {
                return values1;
            }
            else 
            {
                return values2;
            }
        }
    }
}
