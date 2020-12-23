using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int member = int.Parse(Console.ReadLine());
            int a = 1;
            int b = 1;
            int temp;
            int[] arrayFibonacci = new int[member];
            if (member > 1)
            {
                arrayFibonacci[0] = a;
                arrayFibonacci[1] = b;
            }
            else
            {
                arrayFibonacci[0] = a;
            }
            for (int i = 2; i < member; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
                arrayFibonacci[i] = temp;
            }
            Console.WriteLine(arrayFibonacci[arrayFibonacci.Length - 1]);
        }

    }
}
