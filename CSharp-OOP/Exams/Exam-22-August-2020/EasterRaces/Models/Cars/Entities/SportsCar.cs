using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int Min_Horse_Power = 250;
        private const int Max_Horse_Power = 450;
        private const int Cubic_Centimeters = 3000;

        public SportsCar(string model, int horsePower) : base(model, horsePower, Cubic_Centimeters, Min_Horse_Power, Max_Horse_Power)
        {
        }
    }
}
