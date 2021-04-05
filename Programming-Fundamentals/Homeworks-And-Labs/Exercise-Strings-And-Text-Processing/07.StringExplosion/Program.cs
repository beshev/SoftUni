using System;
using System.Linq;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToList();
            int explosion = 0;
            for (int i = 0; i < text.Count - 1; i++)
            {
                if (text[i] == '>')
                {
                    explosion += int.Parse(text[i + 1].ToString()) - 1;
                    text.RemoveAt(i + 1);
                    while (explosion != 0)
                    {
                        if (i < text.Count - 1)
                        {
                            if (text[i + 1] != '>')
                            {
                                text.RemoveAt(i + 1);
                                explosion--;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(string.Empty, text));
        }
    }
}
