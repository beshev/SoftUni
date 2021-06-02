using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _09.FindLatest10Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(GetLatestProjects(db));

        }



        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new { p.Name, p.Description, StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
