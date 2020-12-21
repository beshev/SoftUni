using System;

namespace _06.ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            switch (name)
            {
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                case "USA":
                case "England":
                    Console.WriteLine("English");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
