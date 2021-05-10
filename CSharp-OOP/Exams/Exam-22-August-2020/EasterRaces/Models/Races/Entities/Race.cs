using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string _name;
        private int _laps;
        private readonly ICollection<IDriver> _drivers;

        public Race(string name, int laps)
        {
            _name = name;
            _laps = laps;
            _drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this._name = value;
            }
        }

        public int Laps
        {
            get => this._laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this._laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this._drivers.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this._drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this._drivers.Add(driver);
        }
    }
}
