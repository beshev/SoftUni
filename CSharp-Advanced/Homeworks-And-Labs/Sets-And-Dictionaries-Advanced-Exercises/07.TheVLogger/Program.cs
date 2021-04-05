using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VloggerInfo> vloggers = new Dictionary<string, VloggerInfo>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] cmdArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentVlogger = cmdArg[0];
                string command = cmdArg[1];
                if (command == "joined")
                {
                    if (vloggers.ContainsKey(currentVlogger) == false)
                    {
                        vloggers.Add(currentVlogger, new VloggerInfo());
                    }
                }
                if (command == "followed")
                {
                    string vloggerToFollow = cmdArg[2];
                    bool isValid = (currentVlogger != vloggerToFollow)
                        && (vloggers.ContainsKey(currentVlogger) && vloggers.ContainsKey(vloggerToFollow))
                        && (vloggers[vloggerToFollow].Followers.Contains(currentVlogger) == false);
                    if (isValid)
                    {
                        vloggers[vloggerToFollow].Followers.Add(currentVlogger);
                        vloggers[currentVlogger].Following++;
                    }
                }
                input = Console.ReadLine();
            }
            PrintVloggers(vloggers);
        }

        private static void PrintVloggers(Dictionary<string, VloggerInfo> vloggers)
        {
            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count()} vloggers in its logs.");
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Followers.Count())
                .ThenBy(x => x.Value.Following))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : " +
                    $"{vlogger.Value.Followers.Count()} followers, {vlogger.Value.Following} following");
                if (counter == 1)
                {
                    Console.WriteLine(vlogger.Value.ToString());
                }
                counter++;
            }
        }
    }

    class VloggerInfo
    {
        public List<string> Followers { get; set; }

        public int Following { get; set; }

        public VloggerInfo()
        {
            Followers = new List<string>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var vloger in Followers.OrderBy(x => x))
            {
                sb.AppendLine($"*  {vloger}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
