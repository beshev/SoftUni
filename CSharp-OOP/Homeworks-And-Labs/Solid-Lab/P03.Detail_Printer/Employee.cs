namespace P03.DetailPrinter
{
    using System;
    public class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual void PrintEmoloyee()
        {
            Console.WriteLine(this.Name);
        }
    }
}
