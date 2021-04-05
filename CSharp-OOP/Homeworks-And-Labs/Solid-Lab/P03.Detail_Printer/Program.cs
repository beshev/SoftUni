using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IList<Employee> employees = new List<Employee>();
            Employee maniger = new Manager("Buksan",new List<string> {"Project","Tasks","TeamCount" });
            Employee developer = new Employee("BukiHud");
            Employee teamLeader = new TeamLeader("GogoGO",new List<string> {"Peshko","Anton","Boris","Moris"});

            employees.Add(developer);
            employees.Add(teamLeader);
            employees.Add(maniger);

            DetailsPrinter detailPrinter = new DetailsPrinter(employees);
            detailPrinter.PrintDetails();
            
        }
    }
}
