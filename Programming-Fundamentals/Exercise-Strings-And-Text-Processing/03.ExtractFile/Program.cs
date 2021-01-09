using System;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] nameAndExtension = path[path.Length - 1]
                .Split('.').ToArray();
            Console.WriteLine($"File name: {nameAndExtension[0]}");
            Console.WriteLine($"File extension: {nameAndExtension[1]}");
        }
    }
}
