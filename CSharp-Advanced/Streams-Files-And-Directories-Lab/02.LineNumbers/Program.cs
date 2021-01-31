using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Dell\source\repos\StreamsFilesAndDirectoriesLab\01.OddLines\input.txt"))
            {
                string currentLine = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter("../../../input.txt"))
                {
                    int counter = 1;
                    while (currentLine != null)
                    {
                        Console.WriteLine($"{counter}.  {currentLine}");
                        writer.WriteLine($"{counter}.  {currentLine}");
                        currentLine = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
