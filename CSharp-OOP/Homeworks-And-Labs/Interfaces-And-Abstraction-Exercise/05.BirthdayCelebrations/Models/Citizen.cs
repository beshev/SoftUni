using _05.BirthdayCelebrations.Models.Contracts;

namespace _05.BirthdayCelebrations
{
    public class Citizen : Identifiable, IBirthdatefiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
