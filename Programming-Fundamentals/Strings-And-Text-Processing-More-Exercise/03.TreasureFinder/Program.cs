using System;
using System.Linq;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            while (input != "find")
            {
                FindTypeAndCoordinate(input, keys);
                input = Console.ReadLine();
            }

            static void FindTypeAndCoordinate(string input, int[] keys)
            {
                char[] text = input.ToCharArray();
                int counterForKey = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (counterForKey == keys.Length)
                    {
                        counterForKey = 0;
                    }
                    text[i] = (char)(text[i] - keys[counterForKey]);
                    counterForKey++;
                }
                string decryptMessage = new string(text);
                string type = decryptMessage.Substring(decryptMessage.IndexOf('&') + 1,
                    decryptMessage.LastIndexOf('&') - 1 - decryptMessage.IndexOf('&'));
                string coordinates = decryptMessage.Substring(decryptMessage.IndexOf('<') + 1,
                    decryptMessage.IndexOf('>') - 1 - decryptMessage.IndexOf('<'));
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
