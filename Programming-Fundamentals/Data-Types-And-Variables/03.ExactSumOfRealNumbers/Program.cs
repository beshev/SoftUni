﻿using System;

namespace _03.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                double numbers = double.Parse(Console.ReadLine());
                sum += (decimal)numbers;
            }
            Console.WriteLine(sum);
        }
    }
}
