using _07.MilitaryElite.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Core
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; private set; }

        public void CompleteMission(Mission mission)
        {
            mission.State = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine($"Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
