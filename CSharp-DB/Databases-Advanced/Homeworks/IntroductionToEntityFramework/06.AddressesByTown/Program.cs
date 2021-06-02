using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _06.AddressesByTown
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(GetAddressesByTown(db));

        }


        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
               .Select(a => new { a.Town, a.AddressText, EmployeesCount = a.Employees.Count })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
