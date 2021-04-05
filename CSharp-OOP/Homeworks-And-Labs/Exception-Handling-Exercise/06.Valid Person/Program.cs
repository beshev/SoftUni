using System;

namespace _06.Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person noLastName = new Person("Ivan", null, 63);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person tooOldForThisProgram = new Person("Strong", "Jay", 121);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }
        }
    }
}
