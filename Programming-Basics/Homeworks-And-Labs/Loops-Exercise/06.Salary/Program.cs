using System;

namespace _06.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Read Input
            int numTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            // 2Find Name of Site
            // 2.1  Find Salary Dicount 
            for (int i = 0; i < numTabs; i++)
            {
                string nameSite = Console.ReadLine();
                if (nameSite == "Facebook")
                {
                    salary -= 150;
                }
                else if (nameSite == "Instagram")
                {
                    salary -= 100;
                }
                else if (nameSite == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }                
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
           

            
         
        }
    }
}
