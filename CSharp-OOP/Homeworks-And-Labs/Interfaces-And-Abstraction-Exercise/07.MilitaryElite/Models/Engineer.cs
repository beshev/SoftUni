using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Core
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine($"Repairs:");
            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
