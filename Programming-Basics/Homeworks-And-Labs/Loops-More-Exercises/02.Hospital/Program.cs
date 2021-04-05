using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read Input 
            int numDaysReview = int.Parse(Console.ReadLine());
            int numDoctors = 7;
            int numTreated = 0;
            int numUtreated = 0;

            for (int i = 1; i <= numDaysReview; i++)
            {
                if (i % 3 == 0)
                {
                    if (numUtreated > numTreated)
                    {
                        numDoctors++;
                    }
                }
                int numPatients = int.Parse(Console.ReadLine());
                // 2. Find Nums Of Treated patients
                if (numDoctors >= numPatients)
                {
                    numTreated += numPatients;
                }
                // 2.1 Find Nums of Unthreated patients
                else
                {

                    numUtreated += numPatients - numDoctors;
                    numTreated += numDoctors;


                }                

            }
            // 3. Print Output
            Console.WriteLine($"Treated patients: {numTreated}.");
            Console.WriteLine($"Untreated patients: {numUtreated}.");
        }
    }
}
