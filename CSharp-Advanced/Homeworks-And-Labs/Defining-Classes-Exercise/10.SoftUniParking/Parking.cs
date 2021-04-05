using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

        public int Count
        {
            get
            {
                return Cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (Cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(x => x.RegistrationNumber == registrationNumber) == false)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car car = Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                Cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var register in registrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == register);
            }
        }
    }
}
