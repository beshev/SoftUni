using System;

namespace _05.PasswordGanerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int y = 1; y<= n; y++)
                {
                    
                    for (char a = 'a'; a < 'a' + L; a++)
                    {
                        for (char a1 = 'a'; a1 < 'a' + L; a1++)
                        {
                            for (int j = 1; j <= n; j++)
                            {
                                if (j > i && j > y)
                                {
                                    Console.Write($"{i}{y}{a}{a1}{j} ");
                                }
                            }
                        }
                    }
                
                }

            }



        }
    }
}
