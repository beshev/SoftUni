using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Core
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; }
    }
}
