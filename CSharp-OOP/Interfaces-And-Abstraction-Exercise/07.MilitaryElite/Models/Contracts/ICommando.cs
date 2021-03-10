using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Contracts
{
    public interface ICommando
    {
        public List<Mission> Missions { get; }

        public void CompleteMission(Mission mission);
    }
}
