using System;

namespace _01.PipeInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumePool = int.Parse(Console.ReadLine());
            int pipe1 = int.Parse(Console.ReadLine());
            int pipe2 = int.Parse(Console.ReadLine());
            double hoursMiss = double.Parse(Console.ReadLine());
            double volumePipe1 = pipe1 * hoursMiss;
            double volumePipe2 = pipe2 * hoursMiss;
            double pipesSum = volumePipe1 + volumePipe2;

            if (volumePool >= pipesSum)
            {
                double procentPool = (volumePool * 1.0) / 100;
                double procentPipes = (pipesSum * 1.0) / 100;
                Console.WriteLine($"The pool is {pipesSum / procentPool:f2}% full. Pipe 1: {volumePipe1 / procentPipes:f2}%. Pipe 2: {volumePipe2 / procentPipes:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hoursMiss:f2} hours the pool overflows with {pipesSum - volumePool:f2} liters.");
            }

        }
    }
}
