using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
