namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(XmlProjectImportModel[]), new XmlRootAttribute("Projects"));
            using var reader = new StringReader(xmlString);
            var xmlProjects = (XmlProjectImportModel[])serializer.Deserialize(reader);

            var sb = new StringBuilder();

            foreach (var project in xmlProjects)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                var isOpenDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }

                DateTime? dueDate = null;
                if (!string.IsNullOrWhiteSpace(project.DueDate))
                {
                    DateTime dueDateDto;

                    bool isDueDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateDto);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateDto;
                }

                var currentProject = new Project
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                };


                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    var isTaskOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    var isTaskDueDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };

                    currentProject.Tasks.Add(currentTask);
                }

                context.Projects.Add(currentProject);
                sb.AppendLine
                    ($"Successfully imported project - {project.Name} with {currentProject.Tasks.Count} tasks.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var jsonEmployees = JsonConvert.DeserializeObject<JsonEmployeeImport[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var employee in jsonEmployees)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentEmployee = new Employee
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone,
                };

                foreach (var task in employee.Tasks.Distinct())
                {
                    var currentTask = context.Tasks.Find(task);
                    if (currentTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask
                    {
                        Task = currentTask
                    };

                    currentEmployee.EmployeesTasks.Add(employeeTask);
                }

                context.Employees.Add(currentEmployee);

                sb.AppendLine
                    ($"Successfully imported employee - {currentEmployee.Username} with {currentEmployee.EmployeesTasks.Count} tasks.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}