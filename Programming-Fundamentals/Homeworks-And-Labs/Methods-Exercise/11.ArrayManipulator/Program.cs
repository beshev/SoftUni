using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split().ToArray();
                if (command[0] == "exchange")
                {
                    int indexExchange = int.Parse(command[1].ToString());
                    if (indexExchange < 0 || indexExchange > array.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        ArrayExchange(array, indexExchange);
                    }
                }
                else if (command[0] == "max")
                {
                    CheckMaxEvenOrOddIndex(command[1].ToString(), array);
                }
                else if (command[0] == "min")
                {
                    CheckMinEvenOrOddIndex(command[1].ToString(), array);
                }
                else if (command[0] == "first")
                {
                    PrintFirstEvenOrOddNumbers(command[2], int.Parse(command[1].ToString()), array);
                }
                else if (command[0] == "last")
                {
                    PrintLastEvenOrOddNumbers(command[2], int.Parse(command[1].ToString()), array);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"[{String.Join(", ",array)}]");
        }

        static void ArrayExchange(int[] array, int indexExchange)
        {
            int[] firstArray = new int[indexExchange + 1];
            for (int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = array[i];
            }
            int[] secondArray = new int[array.Length - (indexExchange + 1)];
            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = array[indexExchange + 1 + i];
            }
            for (int i = 0; i < secondArray.Length; i++)
            {
                array[i] = secondArray[i];
            }
            for (int i = 0; i < firstArray.Length; i++)
            {
                array[secondArray.Length + i] = firstArray[i];
            }

        }

        static void CheckMaxEvenOrOddIndex(string evenOrOdd, int[] array)
        {
            int maxEvenOrOdd = int.MinValue;
            int maxIdex = 0;
            bool haveEvenOrOdd = false;
            if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int currentEven = 0;
                    if (array[i] % 2 == 0)
                    {
                        haveEvenOrOdd = true;
                        currentEven = array[i];
                        if (currentEven >= maxEvenOrOdd)
                        {
                            maxEvenOrOdd = currentEven;
                            maxIdex = i;
                        }
                    }
                }
                if (!haveEvenOrOdd)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIdex);
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int currentOdd = 0;
                    if (array[i] % 2 != 0)
                    {
                        haveEvenOrOdd = true;
                        currentOdd = array[i];
                        if (currentOdd >= maxEvenOrOdd)
                        {
                            maxEvenOrOdd = currentOdd;
                            maxIdex = i;
                        }
                    }
                }
                if (!haveEvenOrOdd)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIdex);
                }

            }

        }

        static void CheckMinEvenOrOddIndex(string evenOrOdd, int[] array)
        {
            int minEvenOrOdd = int.MaxValue;
            int minIdex = 0;
            bool haveEvenOrOdd = false;
            if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int currentEven = 0;
                    if (array[i] % 2 == 0)
                    {
                        haveEvenOrOdd = true;
                        currentEven = array[i];
                        if (currentEven <= minEvenOrOdd)
                        {
                            minEvenOrOdd = currentEven;
                            minIdex = i;
                        }
                    }
                }
                if (!haveEvenOrOdd)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIdex);
                }
            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int currentOdd = 0;
                    if (array[i] % 2 != 0)
                    {
                        haveEvenOrOdd = true;
                        currentOdd = array[i];
                        if (currentOdd <= minEvenOrOdd)
                        {
                            minEvenOrOdd = currentOdd;
                            minIdex = i;
                        }
                    }
                }
                if (!haveEvenOrOdd)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIdex);
                }

            }

        }

        static void PrintFirstEvenOrOddNumbers(string evenOrOdd, int count, int[] array)
        {
            int counterEvenOrOdd = 0;
            int[] newArray;
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        counterEvenOrOdd++;
                    }
                }

                if (counterEvenOrOdd == 0)
                {
                    Console.WriteLine("[]");
                }
                else if (count <= counterEvenOrOdd)
                {
                    newArray = new int[count];
                    int counter = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == count)
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }
                else
                {
                    newArray = new int[counterEvenOrOdd];
                    int counter = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == counterEvenOrOdd)
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }

            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        counterEvenOrOdd++;
                    }
                }
                if (counterEvenOrOdd == 0)
                {
                    Console.WriteLine("[]");
                }
                else if (count <= counterEvenOrOdd)
                {
                    newArray = new int[count];
                    int counter = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == count)
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }
                else
                {
                    newArray = new int[counterEvenOrOdd];
                    int counter = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == counterEvenOrOdd)
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }

            }

        }

        static void PrintLastEvenOrOddNumbers(string evenOrOdd, int count, int[] array)
        {
            int counterEvenOrOdd = 0;
            int[] newArray;
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else if (evenOrOdd == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        counterEvenOrOdd++;
                    }
                }

                if (counterEvenOrOdd == 0)
                {
                    Console.WriteLine("[]");
                }
                else if (count <= counterEvenOrOdd)
                {
                    newArray = new int[count];
                    int counter = 0;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 == 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == count)
                            {
                                break;
                            }
                        }
                    }
                    Array.Reverse(newArray);
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }
                else
                {
                    newArray = new int[counterEvenOrOdd];
                    int counter = 0;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 == 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == counterEvenOrOdd)
                            {
                                break;
                            }
                        }
                    }
                    Array.Reverse(newArray);
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }

            }
            else if (evenOrOdd == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        counterEvenOrOdd++;
                    }
                }
                if (counterEvenOrOdd == 0)
                {
                    Console.WriteLine("[]");
                }
                else if (count <= counterEvenOrOdd)
                {
                    newArray = new int[count];
                    int counter = 0;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 != 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == count)
                            {
                                break;
                            }
                        }
                    }
                    Array.Reverse(newArray);
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }
                else
                {
                    newArray = new int[counterEvenOrOdd];
                    int counter = 0;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] % 2 != 0)
                        {
                            newArray[counter] = array[i];
                            counter++;
                            if (counter == counterEvenOrOdd)
                            {
                                break;
                            }
                        }
                    }
                    Array.Reverse(newArray);
                    Console.WriteLine($"[{String.Join(", ", newArray)}]");
                }

            }

        }
    }
}
