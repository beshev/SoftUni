using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _11.FindEmployeesByFirstNameStartingWithSa
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));

        }



        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().Trim();
        }
    }
}
