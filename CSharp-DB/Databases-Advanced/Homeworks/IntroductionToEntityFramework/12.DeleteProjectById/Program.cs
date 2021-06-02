using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _12.DeleteProjectById
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(DeleteProjectById(db));

        }


        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .Include(p => p.EmployeesProjects)
                .SingleOrDefault(p => p.ProjectId == 2);
            if (project != null)
            {
                foreach (var projectType in project.EmployeesProjects)
                {
                    context.EmployeesProjects.Remove(projectType);
                }
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var currProject in projects)
            {
                sb.AppendLine($"{currProject.Name}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
