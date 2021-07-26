namespace _01.Inventory.Models
{
    using _01.Inventory.Interfaces;
    using System;

    public abstract class Weapon : IWeapon,IComparable
    {
        public Weapon(int id, int maxCapacity, int ammunition)
        {
            this.Id = id;
            this.MaxCapacity = maxCapacity;
            this.Ammunition = ammunition;
        }

        public int Id { get; private set; }
        public int Ammunition { get; set; }
        public int MaxCapacity { get; set; }
        public Category Category { get; set; }

        public int CompareTo(object obj)
        {
            var currentObj = obj as IWeapon;

            if (this.Id.CompareTo(currentObj.Id) < 0)
            {
                return -1;
            }
            else if (this.Id.CompareTo(currentObj.Id) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
