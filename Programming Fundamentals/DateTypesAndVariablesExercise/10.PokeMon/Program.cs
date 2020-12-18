using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            uint powerStart = uint.Parse(Console.ReadLine());
            uint distance = uint.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int targetPoked = 0;
            uint pokePower = powerStart;
            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetPoked++;
                if (pokePower == powerStart / 2)
                {
                    if (exhaustionFactor == 0)
                    {
                        continue;
                    }
                    else
                    {
                        pokePower = pokePower / (uint)exhaustionFactor;
                    }

                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targetPoked);

        }
    }
}
