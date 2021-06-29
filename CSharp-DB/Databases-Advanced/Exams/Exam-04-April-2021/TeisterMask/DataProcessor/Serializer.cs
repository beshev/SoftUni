namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects.ToArray()
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new XmlProjectViewModel
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new XmlTaskViewModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(XmlProjectViewModel[]), new XmlRootAttribute("Projects"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using var writer = new StringWriter();
            serializer.Serialize(writer, projects, ns);



            return writer.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees.ToArray()
                   .Where(e => e.EmployeesTasks.Count > 0)
                   .Select(e => new
                   {
                       Username = e.Username,
                       Tasks = e.EmployeesTasks
                       .Where(e => e.Task.OpenDate >= date)
                       .OrderByDescending(e => e.Task.DueDate)
                       .ThenBy(e => e.Task.Name)
                       .Select(t => new
                       {
                           TaskName = t.Task.Name,
                           OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                           DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                           LabelType = t.Task.LabelType.ToString(),
                           ExecutionType = t.Task.ExecutionType.ToString()
                       })
                       .ToArray()
                   })
                   .OrderByDescending(e => e.Tasks.Count())
                   .ThenBy(e => e.Username)
                   .Take(10)
                   .ToArray();


            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}