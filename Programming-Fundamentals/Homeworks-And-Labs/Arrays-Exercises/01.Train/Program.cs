using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int vagonsNumbers = int.Parse(Console.ReadLine());
            int sum = 0;
            string[] allPeaple = new string[vagonsNumbers];
            for (int i = 0; i < vagonsNumbers; i++)
            {
                int peaplesInVagons = int.Parse(Console.ReadLine());
                sum += peaplesInVagons;
                allPeaple[i] = peaplesInVagons.ToString();
            }
            foreach (var item in allPeaple)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
