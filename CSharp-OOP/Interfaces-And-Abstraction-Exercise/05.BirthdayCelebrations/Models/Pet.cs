using _05.BirthdayCelebrations.Models.Contracts;

namespace _05.BirthdayCelebrations.Models
{
    class Pet : IBirthdatefiable
    {
        public Pet(string name , string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; private set; }
    }
}
