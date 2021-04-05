using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Employee employee)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee current = this.data.FirstOrDefault(e => e.Name == name);
            if (current != null)
            {
                this.data.Remove(current);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return this.data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return this.data.FirstOrDefault(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employy in data)
            {
                sb.AppendLine(employy.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
