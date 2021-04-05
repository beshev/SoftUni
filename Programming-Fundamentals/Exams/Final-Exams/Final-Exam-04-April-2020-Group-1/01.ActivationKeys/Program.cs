using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Generate")
            {
                string[] cmdArg = input
                    .Split(">>>")
                    .ToArray();
                if (cmdArg[0] == "Slice")
                {
                    SliceSting(ref activationKey, cmdArg);
                }
                else if (cmdArg[0] == "Contains")
                {
                    if (activationKey.Contains(cmdArg[1]))
                    {
                        Console.WriteLine($"{activationKey} contains {cmdArg[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else
                if (cmdArg[0] == "Flip")
                {
                    FlipSting(ref activationKey, cmdArg);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static void SliceSting(ref string activationKey, string[] cmdArg)
        {

            int firstIndex = int.Parse(cmdArg[1]);
            int secondIndex = int.Parse(cmdArg[2]);
            int startindex = Math.Min(firstIndex, secondIndex);
            int range = Math.Abs(firstIndex - secondIndex);
            activationKey = activationKey.Remove(startindex, range);
            Console.WriteLine(activationKey);
        }

        static void FlipSting(ref string activationKey, string[] cmdArg)
        {

            int firstIndex = int.Parse(cmdArg[2]);
            int secondIndex = int.Parse(cmdArg[3]);
            int startindex = Math.Min(firstIndex, secondIndex);
            int range = Math.Abs(firstIndex - secondIndex);
            string oldString = activationKey.Substring(startindex, range);
            string newString = activationKey.Substring(startindex, range).ToLower();
            if (cmdArg[1] == "Upper")
            {
                newString = newString.ToUpper();
            }
            activationKey = activationKey.Replace(oldString, newString);
            Console.WriteLine(activationKey);
        }
    }
}
