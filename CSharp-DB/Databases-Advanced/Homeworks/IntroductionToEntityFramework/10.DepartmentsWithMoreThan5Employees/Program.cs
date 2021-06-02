using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _10.DepartmentsWithMoreThan5Employees
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));

        }



        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    MagagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                });

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.MagagerFullName}");
                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
