using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        public static object StringBilder { get; private set; }

        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
            List<string> command = Console.ReadLine().Split().ToList();
            bool isChange = false;
            while (command[0] != "end")
            {
                if (command[0] == "Add" || command[0] == "Remove" || command[0] == "RemoveAt" || command[0] == "Insert")
                {
                    isChange = true;
                }
                if (command[0] == "Contains")
                {
                    CheckListContainsNumber(list, int.Parse(command[1]));
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEvenNumbers(list);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOddNumbers(list);
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(list));
                }
                else if (command[0] == "Filter")
                {
                    PrintsNumbersByConditonsOfGivenOperator(list,command[1],int.Parse(command[2]));
                }
                else if (command[0] == "Add")
                {
                    AddNumber(list, int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    RemoveNumber(list, int.Parse(command[1]));
                }
                else if (command[0] == "RemoveAt")
                {
                    RemuveNumberFromIdex(list, int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    InsertNumberByIdex(list, int.Parse(command[1]), int.Parse(command[2]));
                }
                command = Console.ReadLine().Split().ToList();
            }
            if (isChange)
            {
                Console.WriteLine(String.Join(" ", list));
            }
        }

        static void CheckListContainsNumber(List<int> list, int number)
        {
            if (list.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEvenNumbers(List<int> list)
        {
            StringBuilder even = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    even.Append(list[i].ToString() + " ");
                }
            }
            Console.WriteLine(String.Join(" ", even));
        }

        static void PrintOddNumbers(List<int> list)
        {
            StringBuilder even = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    even.Append(list[i].ToString() + " ");
                }
            }
            Console.WriteLine(String.Join(" ", even));
        }

        static int GetSum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        static void PrintsNumbersByConditonsOfGivenOperator(List<int> list, string condition, int number)
        {
            StringBuilder result = new StringBuilder();
            if (condition == ">")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > number)
                    {
                        result.Append(list[i] + " ");
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] >= number)
                    {
                        result.Append(list[i] + " ");
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] <= number)
                    {
                        result.Append(list[i] + " ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] < number)
                    {
                        result.Append(list[i] + " ");
                    }
                }
            }
            Console.WriteLine(result);
        }

        static void AddNumber(List<int> list, int numberAdd)
        {
            list.Add(numberAdd);
        }

        static void RemoveNumber(List<int> list, int remuveNumber)
        {
            list.Remove(remuveNumber);
        }

        static void RemuveNumberFromIdex(List<int> list, int index)
        {
            list.RemoveAt(index);
        }

        static void InsertNumberByIdex(List<int> list, int number, int index)
        {
            list.Insert(index, number);
        }

    }
}
