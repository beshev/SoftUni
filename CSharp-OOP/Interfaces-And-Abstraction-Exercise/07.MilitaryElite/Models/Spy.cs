using _07.MilitaryElite.Models.Contracts;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Spy : Soldier,ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
                .AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
