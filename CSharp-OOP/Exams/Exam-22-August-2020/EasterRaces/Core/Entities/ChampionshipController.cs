using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository _drivers;
        private CarRepository _cars;
        private RaceRepository _races;

        public ChampionshipController()
        {
            _drivers = new DriverRepository();
            _cars = new CarRepository();
            _races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = _drivers.Models.FirstOrDefault(x => x.Name == driverName);
            ICar car = _cars.Models.FirstOrDefault(x => x.Model == carModel);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            driver.AddCar(car);
            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = _races.Models.FirstOrDefault(x => x.Name == raceName);
            IDriver driver = _drivers.Models.FirstOrDefault(x => x.Name == driverName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (this._cars.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            this._cars.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (_drivers.Models.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            this._drivers.Add(driver);
            return $"Driver {driver.Name} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (_races.Models.Any(x => x.Name == race.Name))
            {
                throw new InvalidOperationException($"Race {race.Name} is already create.");
            }

            _races.Add(race);
            return $"Race {race.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = _races.Models.FirstOrDefault(x => x.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            List<IDriver> drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            _races.Remove(race);

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Driver {drivers[0].Name} wins {race.Name} race.");
            result.AppendLine($"Driver {drivers[1].Name} is second in {race.Name} race.");
            result.AppendLine($"Driver {drivers[2].Name} is third in {race.Name} race.");

            return result.ToString().TrimEnd();

        }
    }
}
