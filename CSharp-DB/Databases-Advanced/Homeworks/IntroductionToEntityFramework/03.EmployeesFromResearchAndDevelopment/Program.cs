using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _03.EmployeesFromResearchAndDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));

        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var result = context.Employees
                            .Where(e => e.Department.Name == "Research and Development")
                            .OrderBy(e => e.Salary)
                            .ThenByDescending(e => e.FirstName)
                            .Select(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}"))
                            .ToArray();

            return sb.ToString().TrimEnd();
        }
    }
}
