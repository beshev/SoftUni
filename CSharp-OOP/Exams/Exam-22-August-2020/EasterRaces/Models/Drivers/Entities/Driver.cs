using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string _name;

        public Driver(string name)
        {
            this.Name = name;
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


        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
