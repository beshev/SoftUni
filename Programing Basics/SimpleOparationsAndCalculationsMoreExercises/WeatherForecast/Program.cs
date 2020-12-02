using System;
using System.Xml;

namespace _13.If_else
{
    class Program
    {
        static void Main(string[] args)
        {
            string sunny = Console.ReadLine();
            if (sunny == "sunny")
            {
                Console.WriteLine("It's warm outside!");
            }
            else
            {
                Console.WriteLine("It's cold outside!");
            }

        }
    }
}

