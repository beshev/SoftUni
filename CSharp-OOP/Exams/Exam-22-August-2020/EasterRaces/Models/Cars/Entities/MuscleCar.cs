using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int Min_Horse_Power = 400;
        private const int Max_Horse_Power = 600;
        private const int Cubic_Centimeters = 5000;

        public MuscleCar(string model, int horsePower) : base(model, horsePower, Cubic_Centimeters, Min_Horse_Power, Max_Horse_Power)
        {
        }
    }
}
