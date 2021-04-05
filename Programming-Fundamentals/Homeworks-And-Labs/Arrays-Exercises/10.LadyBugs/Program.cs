using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexsOfLadyBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];
            for (int i = 0; i < indexsOfLadyBugs.Length; i++)
            {
                if (indexsOfLadyBugs[i] < 0 || indexsOfLadyBugs[i] > field.Length - 1)
                {
                    continue;
                }
                else
                {
                    field[indexsOfLadyBugs[i]] = 1;
                }
            }
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int ladybugIdex = int.Parse(command[0].ToString());
                string directionFly = command[1].ToString();
                int flyLenght = int.Parse(command[2].ToString());
                if (flyLenght == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (ladybugIdex < 0 || ladybugIdex > field.Length - 1)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (directionFly == "right")
                {
                    if (field[ladybugIdex] == 1)
                    {                     
                        if (ladybugIdex + flyLenght > field.Length - 1)
                        {
                            field[ladybugIdex] = 0;
                        }
                        else if (field[ladybugIdex + flyLenght] == 1)
                        {
                            for (int i = ladybugIdex + flyLenght; i < field.Length; i += flyLenght)
                            {
                                if (field[i] != 1)
                                {
                                    field[i] = 1;
                                    break;
                                }
                            }
                            field[ladybugIdex] = 0;
                        }
                        else
                        {
                            field[ladybugIdex + flyLenght] = 1;
                            field[ladybugIdex] = 0;
                        }
                    }
                }
                if (directionFly == "left")
                {
                    if (field[ladybugIdex] == 1)
                    {
                        if (ladybugIdex - flyLenght < 0)
                        {
                            field[ladybugIdex] = 0;
                        }
                        else if (field[ladybugIdex - flyLenght] == 1)
                        {
                            for (int i = ladybugIdex - flyLenght; 0 <= i; i -= flyLenght)
                            {
                                if (field[i] != 1)
                                {
                                    field[i] = 1;
                                    break;
                                }
                            }
                            field[ladybugIdex] = 0;
                        }
                        else
                        {
                            field[ladybugIdex - flyLenght] = 1;
                            field[ladybugIdex] = 0;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
