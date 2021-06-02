using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _05.EmployeesAndProjects
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesInPeriod(db));

        }


        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select
                    (
                        ep => new
                        {
                            ep.Project.Name,

                            StartDate =
                            ep.Project.StartDate.
                            ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),

                            EndDate =
                            ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value
                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        }
                    )
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var empoyee in employees)
            {
                sb.AppendLine($"{empoyee.FirstName} {empoyee.LastName} - Manager: {empoyee.ManagerFirstName} {empoyee.ManagerLastName}");

                foreach (var project in empoyee.Projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }


            return sb.ToString().TrimEnd();

        }

    }
}
