using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesFullInformation(db));

        }

        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var result = db.Employees
                            .OrderBy(e => e.EmployeeId)
                            .Select(e => sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"))
                            .ToArray();

            return sb.ToString().TrimEnd();
        }
    }
}
