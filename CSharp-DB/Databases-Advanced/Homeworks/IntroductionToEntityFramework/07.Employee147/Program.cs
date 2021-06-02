using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _07.Employee147
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(GetEmployee147(db));

        }



        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, Projects = e.EmployeesProjects.Select(p => p.Project) })
                .First();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
