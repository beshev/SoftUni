using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface IEngineer
    {
        public List<Repair> Repairs { get; }
    }
}
