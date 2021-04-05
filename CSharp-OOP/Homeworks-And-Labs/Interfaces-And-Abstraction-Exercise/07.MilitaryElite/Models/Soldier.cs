using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return "Null";
        }
    }
}
