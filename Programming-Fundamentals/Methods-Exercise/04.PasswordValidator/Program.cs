using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            CheckPasswordIsBetweenSixAndTenDigits(password);
            CheckPasswordHaveLettersAndDigits(password);
            CheckPasswordHaveTwoOrMoreDigits(password);
            CheckPasswordIsValid(password);
        }

        static void CheckPasswordIsBetweenSixAndTenDigits(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
        }

        static void CheckPasswordHaveLettersAndDigits(string password)
        {
            
            for (int i = 0; i <= password.Length - 1; i++)
            {
                bool haveLetters = (password[i] >= 'a' && password[i] <= 'z') || (password[i] >= 'A' && password[i] <= 'Z');
                bool haveDigits = password[i] >= '0' && password[i] <= '9';
                if (haveLetters || haveDigits)
                {

                }
                else
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }
        }

        static void CheckPasswordHaveTwoOrMoreDigits(string password)
        {
            int counter = 0;
            for (int i = 0; i <= password.Length - 1; i++)
            {
                bool haveDigits = password[i] >= '0' && password[i] <= '9';
                if (haveDigits)
                {
                    counter++;
                }
            }
            if (counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static void CheckPasswordIsValid(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
            }
            for (int i = 0; i <= password.Length - 1; i++)
            {
                bool haveLetters = (password[i] >= 'a' && password[i] <= 'z') || (password[i] >= 'A' && password[i] <= 'Z');
                bool haveDigits = password[i] >= '0' && password[i] <= '9';
                if (haveLetters || haveDigits)
                {
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            int counter = 0;
            for (int i = 0; i <= password.Length - 1; i++)
            {
                bool haveDigits = password[i] >= '0' && password[i] <= '9';
                if (haveDigits)
                {
                    counter++;
                }
            }
            if (counter < 2)
            {
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
