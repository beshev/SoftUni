using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Travel")
            {
                string[] cmdArg = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(cmdArg[1]);
                    string toInsert = cmdArg[2];
                    if (index >= 0 && index < destination.Length)
                    {
                        destination = destination.Insert(index, toInsert);
                    }
                    Console.WriteLine(destination);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int endIndex = int.Parse(cmdArg[2]);
                    bool startIndexIsValid = startIndex >= 0 && startIndex < destination.Length;
                    bool endIndexIsValid = endIndex >= 0 && endIndex < destination.Length;
                    if (startIndexIsValid && endIndexIsValid)
                    {
                        destination = destination.Remove(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine(destination);
                }
                else if (command == "Switch")
                {
                    string oldString = cmdArg[1];
                    string newString = cmdArg[2];
                    if (destination.Contains(oldString))
                    {
                        destination = destination.Replace(oldString, newString);
                    }
                    Console.WriteLine(destination);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
