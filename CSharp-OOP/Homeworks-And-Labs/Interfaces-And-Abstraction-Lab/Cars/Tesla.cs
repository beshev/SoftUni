using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : ICar, IElectricCar
    {

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Battery = battery;
            this.Color = color;
        }

        public int Battery { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }


        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries")
                .AppendLine($"{this.Start()}")
                .AppendLine($"{this.Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}
