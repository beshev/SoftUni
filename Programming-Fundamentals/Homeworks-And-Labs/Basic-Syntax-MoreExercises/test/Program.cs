﻿using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
			int number = int.Parse(Console.ReadLine());
			int number2 = int.Parse(Console.ReadLine());
			int number3 = int.Parse(Console.ReadLine());

			if (number >= number2 && number >= number3)
			{
				Console.WriteLine(number);
				if (number2 >= number3)
				{
					Console.WriteLine(number2);
					Console.WriteLine(number3);
				}
				else
				{
					Console.WriteLine(number3);
					Console.WriteLine(number2);
				}
			}
			if (number2 >= number3 && number2 >= number)
			{
				Console.WriteLine(number2);
				if (number > number3)
				{
					Console.WriteLine(number);
					Console.WriteLine(number3);
				}
				else
				{
					Console.WriteLine(number3);
					Console.WriteLine(number);
				}
			}
			if (number3 >= number2 && number3 >= number)
			{
				Console.WriteLine(number3);
				if (number >= number2)
				{
					Console.WriteLine(number);
					Console.WriteLine(number2);
				}
				else
				{
					Console.WriteLine(number2);
					Console.WriteLine(number);
				}
			}
		}
    }
}
