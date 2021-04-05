namespace _09.ExplicitInterfaces.Models.Contracts
{
    interface IPerson
    {
        public string Name { get; }

        public int Age { get; }

        public string GetName();
    }
}
