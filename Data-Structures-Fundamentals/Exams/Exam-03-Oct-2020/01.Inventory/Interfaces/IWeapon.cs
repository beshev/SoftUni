namespace _01.Inventory.Interfaces
{
    using _01.Inventory.Models;

    public interface IWeapon
    {
        int Id { get;  }

        int Ammunition { get; set; }

        int MaxCapacity { get; set; }

        Category Category { get; set; }
    }
}
