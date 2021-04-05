using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            CheckVariableAndCalculateOrWriteIt(type);
        }

        static void CheckVariableAndCalculateOrWriteIt(string type)
        {
            if (type == "string")
            {
                string variable = Console.ReadLine();
                Console.WriteLine($"${variable}$");
            }
            else if (type == "int")
            {
                int integer = int.Parse(Console.ReadLine());
                Console.WriteLine(integer * 2);
            }
            else if (type == "real")
            {
                double real = double.Parse(Console.ReadLine());
                Console.WriteLine($"{real * 1.5:f2}");
            }
        }
    }
}
