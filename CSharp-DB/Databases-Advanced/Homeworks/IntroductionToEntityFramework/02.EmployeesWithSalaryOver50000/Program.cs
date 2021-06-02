using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _02.EmployeesWithSalaryOver50000
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesWithSalaryOver50000(db));

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var result = context.Employees
                            .Where(e => e.Salary > 50000)
                            .OrderBy(e => e.FirstName)
                            .Select(e => sb.AppendLine($"{e.FirstName} - {e.Salary:f2}"))
                            .ToArray();

            return sb.ToString().TrimEnd();
        }
    }
}
