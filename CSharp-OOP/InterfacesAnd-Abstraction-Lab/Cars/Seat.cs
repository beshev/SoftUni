using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Seat : ICar
    {
        public Seat(string model , string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get ; set; }

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
                .AppendLine($"{this.Color} Seat {this.Model}")
                .AppendLine($"{this.Start()}")
                .AppendLine($"{this.Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}
