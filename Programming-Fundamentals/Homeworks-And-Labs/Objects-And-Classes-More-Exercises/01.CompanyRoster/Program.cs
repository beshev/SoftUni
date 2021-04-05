using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());
            List<string> allDepartments = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split();
                if (!allDepartments.Contains(employeeInfo[2]))
                {
                    allDepartments.Add(employeeInfo[2]);
                }
                Employee currentEmployee = new Employee(employeeInfo[0],
                    decimal.Parse(employeeInfo[1]),
                    employeeInfo[2]);
                employees.Add(currentEmployee);
            }
        }

        public class AllDepartments
        {
            public string NameDapartment { get; set; }

            public List<Employee> Employees { get; set; }
            public AllDepartments()
            {
                Employees = new List<Employee>();
            }
        }

        public class Employee
        {
            public string Name { get; set; }

            public decimal Salary { get; set; }

            public string Department { get; set; }

            public Employee(string name, decimal salary, string department)
            {
                this.Name = name;
                this.Salary = salary;
                this.Department = department;
            }
        }
    }
}
