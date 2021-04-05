using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input;
            string bookName = Console.ReadLine();
            int booksCounter = 0;

            // Find the book or library Capacity;
            string input = Console.ReadLine();
            while (input != "No More Books")
            {
                // Print Output;
                if (input == bookName)
                {
                    Console.WriteLine($"You checked {booksCounter} books and found it. ");
                    break;
                }
                booksCounter++;
                input = Console.ReadLine();
            }
            // Check Library Capacity is full;
            if (input == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {booksCounter} books.");
            }
        }
    }
}
