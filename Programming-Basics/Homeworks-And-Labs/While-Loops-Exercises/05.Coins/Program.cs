using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal resto = decimal.Parse(Console.ReadLine());
            int coinsCounter = 0;
            resto *= 100;

            while (true)
            {
                if (resto >= 200)
                {
                    coinsCounter++;
                    resto -= 200;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 100)
                {
                    coinsCounter++;
                    resto -= 100;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 50)
                {
                    coinsCounter++;
                    resto -= 50;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 20)
                {
                    coinsCounter++;
                    resto -= 20;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 10)
                {
                    coinsCounter++;
                    resto -= 10;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 5)
                {
                    coinsCounter++;
                    resto -= 5;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else if (resto >= 2)
                {
                    coinsCounter++;
                    resto -= 2;
                    if (resto == 0)
                    {
                        break;
                    }
                }
                else
                {
                    coinsCounter++;                   
                    break;
                }
                
            }
            Console.WriteLine(coinsCounter);

        }
    }
}
