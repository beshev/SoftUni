namespace _01.Microsystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computers;

        public Microsystems()
        {
            this.computers = new Dictionary<int, Computer>();
        }

        public void CreateComputer(Computer computer)
        {
            if (this.Contains(computer.Number))
            {
                throw new ArgumentException();
            }

            this.computers.Add(computer.Number, computer);
        }

        public bool Contains(int number)
        {
            return this.computers.ContainsKey(number);
        }

        public int Count() => this.computers.Count;

        public Computer GetComputer(int number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            return this.computers[number];
        }

        public void Remove(int number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            this.computers.Remove(number);
        }

        public void RemoveWithBrand(Brand brand)
        {
            int counter = this.Count();

            foreach (var computer in this.computers)
            {
                if (computer.Value.Brand == brand)
                {
                    computers.Remove(computer.Key);
                }
            }

            if (counter == this.computers.Count)
            {
                throw new ArgumentException();
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            var computer = this.computers[number];

            if (ram > computer.RAM)
            {
                computer.RAM = ram;
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            return this.computers.Values.Where(x => x.Brand == brand).OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            return this.computers.Values.Where(x => x.ScreenSize == screenSize).OrderByDescending(x => x.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            return this.computers.Values.Where(x => x.Color == color).OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return this.computers.Values.Where(x => x.Price >= minPrice && x.Price <= maxPrice).OrderByDescending(x => x.Price);
        }
    }
}
