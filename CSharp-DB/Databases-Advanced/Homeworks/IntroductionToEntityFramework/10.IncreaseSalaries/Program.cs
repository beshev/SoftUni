using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _10.IncreaseSalaries
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(IncreaseSalaries(db));

        }



        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var employee in employees)
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
