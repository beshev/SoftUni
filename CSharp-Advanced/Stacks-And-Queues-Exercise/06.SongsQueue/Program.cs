using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(input);
            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine()
                    .Split("Add ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    string song = new string(command[0]);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
