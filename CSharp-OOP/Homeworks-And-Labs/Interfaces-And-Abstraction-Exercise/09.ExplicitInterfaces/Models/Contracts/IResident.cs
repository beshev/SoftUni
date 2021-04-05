namespace _09.ExplicitInterfaces.Models.Contracts
{
    interface IResident
    {
        public string Name { get; }

        public string Country { get; }

       public string GetName();
    }
}
