using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace _04.AddingANewAddressAndUpdatingEmployee
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SoftUniContext();
            Console.WriteLine(AddNewAddressToEmployee(db));

        }


        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(address);

            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.AddressId = address.AddressId;
            employee.Address = address;

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var result = context.Employees
                            .OrderByDescending(e => e.AddressId)
                            .Select(e => sb.AppendLine($"{e.Address.AddressText}"))
                            .Take(10)
                            .ToArray();

            return sb.ToString().TrimEnd();
        }

    }
}
